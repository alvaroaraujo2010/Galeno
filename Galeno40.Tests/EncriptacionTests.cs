using System;
using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using Sistema.Utilidades;
using Xunit;

namespace Galeno40.Tests
{
    public class EncriptacionTests
    {
        [Fact]
        public void HashPassword_DebeGenerarFormatoV2Valido()
        {
            var hash = Encriptacion.HashPassword("MiClaveSegura123");

            hash.Should().StartWith("v2$");
            hash.Split('$').Should().HaveCount(4);
            hash.Split('$')[1].Should().Be("100000");
        }

        [Fact]
        public void HashPassword_DebeGenerarSaltAleatorio()
        {
            var hash1 = Encriptacion.HashPassword("mismoPassword");
            var hash2 = Encriptacion.HashPassword("mismoPassword");

            hash1.Should().NotBe(hash2,
                "el salt aleatorio debe producir hashes distintos para el mismo password");
        }

        [Fact]
        public void HashPassword_NoDebeAceptarTextoVacioONulo()
        {
            Action act1 = () => Encriptacion.HashPassword("");
            Action act2 = () => Encriptacion.HashPassword(null);

            act1.Should().Throw<ArgumentException>();
            act2.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyPassword_ConHashV2YClaveCorrecta_DebeRetornarSuccess()
        {
            var hash = Encriptacion.HashPassword("PasswordValido");

            var resultado = Encriptacion.VerifyPassword(hash, "PasswordValido");

            resultado.Should().Be(PasswordVerificationResult.Success);
        }

        [Fact]
        public void VerifyPassword_ConHashV2YClaveIncorrecta_DebeRetornarFailed()
        {
            var hash = Encriptacion.HashPassword("PasswordValido");

            var resultado = Encriptacion.VerifyPassword(hash, "PasswordMalo");

            resultado.Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void VerifyPassword_ConHashV2ConIteracionesBajas_DebeRetornarSuccessNeedsRehash()
        {
            var hashBajasIteraciones = GenerarHashV2ConIteraciones("test", 1000, 16, 32);

            var resultado = Encriptacion.VerifyPassword(hashBajasIteraciones, "test");

            resultado.Should().Be(PasswordVerificationResult.SuccessNeedsRehash);
        }

        [Fact]
        public void VerifyPassword_ConHashLegacySHA1YClaveCorrecta_DebeRetornarSuccessNeedsRehash()
        {
            var hashLegacy = GenerarHashLegacySHA1("m1dw550ft");

            var resultado = Encriptacion.VerifyPassword(hashLegacy, "m1dw550ft");

            resultado.Should().Be(PasswordVerificationResult.SuccessNeedsRehash,
                "un hash legacy valido debe poder validarse pero marcarse para migrar a v2");
        }

        [Fact]
        public void VerifyPassword_ConHashLegacySHA1YClaveIncorrecta_DebeRetornarFailed()
        {
            var hashLegacy = GenerarHashLegacySHA1("m1dw550ft");

            var resultado = Encriptacion.VerifyPassword(hashLegacy, "claveEquivocada");

            resultado.Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void VerifyPassword_ConHashVacioONulo_DebeRetornarFailed()
        {
            Encriptacion.VerifyPassword(null, "clave").Should().Be(PasswordVerificationResult.Failed);
            Encriptacion.VerifyPassword("", "clave").Should().Be(PasswordVerificationResult.Failed);
            Encriptacion.VerifyPassword("v2$abc", "").Should().Be(PasswordVerificationResult.Failed);
            Encriptacion.VerifyPassword("v2$abc", null).Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void VerifyPassword_ConHashV2Alterado_DebeRetornarFailed()
        {
            var hash = Encriptacion.HashPassword("test");
            var partes = hash.Split('$');
            partes[3] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
            var hashAlterado = string.Join("$", partes);

            Encriptacion.VerifyPassword(hashAlterado, "test")
                .Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void VerifyPassword_ConHashV2Malformado_DebeRetornarFailedSinExcepcion()
        {
            Encriptacion.VerifyPassword("v2$1000$invalidbase64$", "test")
                .Should().Be(PasswordVerificationResult.Failed);
            Encriptacion.VerifyPassword("v2$noesnumero$xxx$yyy", "test")
                .Should().Be(PasswordVerificationResult.Failed);
            Encriptacion.VerifyPassword("v2$1000$xxx", "test")
                .Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void VerifyPassword_ConHashLegacyTamanoIncorrecto_DebeRetornarFailed()
        {
            var hashTamanoMalo = Convert.ToBase64String(new byte[10]);

            Encriptacion.VerifyPassword(hashTamanoMalo, "cualquiera")
                .Should().Be(PasswordVerificationResult.Failed);
        }

        [Fact]
        public void Migracion_DebePermitirValidarYReemplazarHashLegacyEnUnSoloPaso()
        {
            var hashLegacy = GenerarHashLegacySHA1("miClave");
            var claveEnTextoPlano = "miClave";

            var validacion = Encriptacion.VerifyPassword(hashLegacy, claveEnTextoPlano);
            validacion.Should().Be(PasswordVerificationResult.SuccessNeedsRehash);

            var nuevoHash = Encriptacion.HashPassword(claveEnTextoPlano);
            nuevoHash.Should().StartWith("v2$");

            Encriptacion.VerifyPassword(nuevoHash, claveEnTextoPlano)
                .Should().Be(PasswordVerificationResult.Success);
        }

        private static string GenerarHashLegacySHA1(string textoPlano)
        {
            var sal = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(sal);
            }

            var datos = Encoding.UTF8.GetBytes(textoPlano);
            var salados = new byte[sal.Length + datos.Length];
            Buffer.BlockCopy(sal, 0, salados, 0, sal.Length);
            Buffer.BlockCopy(datos, 0, salados, sal.Length, datos.Length);

            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = sha1.ComputeHash(salados);
                var resultado = new byte[sal.Length + hash.Length];
                Buffer.BlockCopy(sal, 0, resultado, 0, sal.Length);
                Buffer.BlockCopy(hash, 0, resultado, sal.Length, hash.Length);
                return Convert.ToBase64String(resultado);
            }
        }

        private static string GenerarHashV2ConIteraciones(string textoPlano, int iteraciones, int saltBytes, int hashBytes)
        {
            var sal = new byte[saltBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(sal);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(textoPlano, sal, iteraciones))
            {
                var hash = pbkdf2.GetBytes(hashBytes);
                return $"v2${iteraciones}${Convert.ToBase64String(sal)}${Convert.ToBase64String(hash)}";
            }
        }
    }
}
