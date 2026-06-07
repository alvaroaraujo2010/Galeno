using System;
using System.Security.Cryptography;
using System.Text;

namespace Sistema.Utilidades
{
    public enum PasswordVerificationResult
    {
        Failed,
        Success,
        SuccessNeedsRehash
    }

    public class Encriptacion
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;
        private const int LegacySaltSize = 4;
        private const int LegacyHashSize = 20;
        private const string V2Prefix = "v2$";

        //********************************************************************
        // HashPassword (PBKDF2-SHA256, formato v2$)
        //********************************************************************
        /// <summary>
        /// Genera un hash seguro con PBKDF2-HMAC-SHA256.
        /// Formato: v2${iteraciones}${salt Base64}${hash Base64}.
        /// </summary>
        public static String HashPassword(String password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("La contraseña no puede ser nula ni vacía.", nameof(password));

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            return string.Format("{0}{1}${2}${3}",
                V2Prefix,
                Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        //********************************************************************
        // FixedTimeEquals (comparación en tiempo constante)
        //********************************************************************
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        //********************************************************************
        // VerifyPassword
        //********************************************************************
        /// <summary>
        /// Verifica una contraseña contra un hash almacenado.
        /// Soporta:
        ///   - v2$iter$salt$hash  (PBKDF2-SHA256, formato nuevo generado por HashPassword)
        ///   - Base64(4 bytes sal + 20 bytes hash)  (SHA1 legacy, migrar a v2 al re-hash)
        /// Firma: VerifyPassword(storedHash, password).
        /// </summary>
        public static PasswordVerificationResult VerifyPassword(String storedHash, String password)
        {
            if (string.IsNullOrEmpty(password))
                return PasswordVerificationResult.Failed;
            if (string.IsNullOrEmpty(storedHash))
                return PasswordVerificationResult.Failed;

            if (storedHash.StartsWith(V2Prefix, StringComparison.Ordinal))
                return VerifyHashedPasswordV2(storedHash, password);

            return VerifyLegacySha1(storedHash, password)
                ? PasswordVerificationResult.SuccessNeedsRehash
                : PasswordVerificationResult.Failed;
        }

        //********************************************************************
        // VerifyHashedPasswordV2
        //********************************************************************
        private static PasswordVerificationResult VerifyHashedPasswordV2(string storedHash, string password)
        {
            var partes = storedHash.Split('$');
            if (partes.Length != 4)
                return PasswordVerificationResult.Failed;

            int iteraciones;
            if (!int.TryParse(partes[1], out iteraciones))
                return PasswordVerificationResult.Failed;

            byte[] salt, expectedHash;
            try
            {
                salt = Convert.FromBase64String(partes[2]);
                expectedHash = Convert.FromBase64String(partes[3]);
            }
            catch (FormatException)
            {
                return PasswordVerificationResult.Failed;
            }

            // Probar primero SHA256 (formato generado por HashPassword) y, si no
            // coincide, SHA1 (compatibilidad con hashes generados con la sobrecarga
            // de 3 argumentos de Rfc2898DeriveBytes).
            bool coincide = false;
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteraciones, HashAlgorithmName.SHA256))
                {
                    coincide = FixedTimeEquals(pbkdf2.GetBytes(expectedHash.Length), expectedHash);
                }
            }
            catch (Exception) { /* probar SHA1 */ }

            if (!coincide)
            {
                try
                {
                    using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteraciones))
                    {
                        coincide = FixedTimeEquals(pbkdf2.GetBytes(expectedHash.Length), expectedHash);
                    }
                }
                catch (Exception)
                {
                    return PasswordVerificationResult.Failed;
                }
            }

            if (!coincide)
                return PasswordVerificationResult.Failed;

            if (iteraciones < Iterations)
                return PasswordVerificationResult.SuccessNeedsRehash;

            return PasswordVerificationResult.Success;
        }

        //********************************************************************
        // VerifyLegacySha1 (LEGACY - solo para migración a v2$)
        //********************************************************************
#pragma warning disable CA5350, CA5351
        /// <summary>
        /// Verifica una contraseña contra un hash legacy SHA1.
        /// Formato: Base64(4 bytes sal + 20 bytes SHA1(sal + UTF8(password))).
        /// </summary>
        private static bool VerifyLegacySha1(string storedHash, string password)
        {
            byte[] storedBytes;
            try { storedBytes = Convert.FromBase64String(storedHash); }
            catch (FormatException) { return false; }

            if (storedBytes.Length != LegacySaltSize + LegacyHashSize)
                return false;

            byte[] salt = new byte[LegacySaltSize];
            byte[] expectedHash = new byte[LegacyHashSize];
            Array.Copy(storedBytes, 0, salt, 0, LegacySaltSize);
            Array.Copy(storedBytes, LegacySaltSize, expectedHash, 0, LegacyHashSize);

            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] salted = new byte[salt.Length + data.Length];
            Array.Copy(salt, 0, salted, 0, salt.Length);
            Array.Copy(data, 0, salted, salt.Length, data.Length);

            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] actualHash = sha1.ComputeHash(salted);
                return FixedTimeEquals(actualHash, expectedHash);
            }
        }
#pragma warning restore CA5350, CA5351

        //********************************************************************
        // fcSISEncritar (LEGACY - usar HashPassword en código nuevo)
        //********************************************************************
#pragma warning disable CA5350, CA5351
        /// <summary>
        /// Método legacy con SHA1. Mantener solo para compatibilidad con hashes antiguos.
        /// </summary>
        [Obsolete("Use HashPassword instead. SHA1 is cryptographically broken.")]
        public static String fcSISEncritar(String tcrTextoaCifrar)
        {
            int lnuCantSal = LegacySaltSize;
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] salero = new byte[lnuCantSal];
            rng.GetNonZeroBytes(salero);
            byte[] bytededatos = Encoding.UTF8.GetBytes(tcrTextoaCifrar);
            byte[] datossalados = new byte[salero.Length + bytededatos.Length];
            Array.Copy(salero, 0, datossalados, 0, salero.Length);
            Array.Copy(bytededatos, 0, datossalados, salero.Length, bytededatos.Length);
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();
            byte[] byteconHash = csp.ComputeHash(datossalados);
            byte[] resultadodeByte = new byte[salero.Length + byteconHash.Length];
            Array.Copy(salero, 0, resultadodeByte, 0, salero.Length);
            Array.Copy(byteconHash, 0, resultadodeByte, salero.Length, byteconHash.Length);
            return Convert.ToBase64String(resultadodeByte);
        }
#pragma warning restore CA5350, CA5351

        //********************************************************************
        // fcSISExtraerHash (LEGACY - usar VerifyPassword en código nuevo)
        //********************************************************************
#pragma warning disable CA5350, CA5351
        /// <summary>
        /// Verifica una contraseña contra un hash legacy SHA1. Solo para migración.
        /// </summary>
        [Obsolete("Use VerifyPassword instead.")]
        public static bool fcSISExtraerHash(String pasSistema, String pasUser)
        {
            return VerifyLegacySha1(pasSistema, pasUser);
        }
#pragma warning restore CA5350, CA5351
    }
}
