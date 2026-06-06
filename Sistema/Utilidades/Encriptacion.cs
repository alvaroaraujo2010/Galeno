using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Sistema.Utilidades
{
    public class Encriptacion
    {
        //********************************************************************
        // fcSISEncritar
        //********************************************************************
        /// <summary>
        /// fcSISEncritar
        /// </summary>
        /// <param name="tcrTextoaCifrar">Texto a Encriptar</param>
        /// <returns>Retorna el Texto Encriptado</returns>
        public static String fcSISEncritar(String tcrTextoaCifrar)
        {
            int lnuCantSal = 4;
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] salero = new byte[lnuCantSal];
            //Genera numeros aleatorios diferentes de cero y los pone en el arreglo
            rng.GetNonZeroBytes(salero);
            //Convertir el texto password a un arreglo de bytes
            byte[] bytededatos = Encoding.UTF8.GetBytes(tcrTextoaCifrar);
            //General otro arreglo para guardar los datos + la sal
            byte[] datossalados = new byte[salero.Length + bytededatos.Length];
            //Copiar la sal a datossalados
            Array.Copy(salero, 0, datossalados, 0, salero.Length);
            //copiar los datos leidos a datos salados
            Array.Copy(bytededatos, 0, datossalados, salero.Length, bytededatos.Length);
            //crear instancia de herramienta de herramienta de creación de Hash
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();
            //crear el Hash
            byte[] byteconHash = csp.ComputeHash(datossalados);
            //Crear el arreglo final con el tamaño "total" + sal
            byte[] resultadodeByte = new byte[salero.Length + byteconHash.Length];
            //Copiar la sal al resultado
            Array.Copy(salero, 0, resultadodeByte, 0, salero.Length);
            //Copiar los datos convertidos al resultado
            Array.Copy(byteconHash, 0, resultadodeByte, salero.Length, byteconHash.Length);
            //Crear un Archivo y meter ahi el arreglo de bytes en modo texto
            return Convert.ToBase64String(resultadodeByte);
        }

        //********************************************************************
        // fcSISExtraerHash
        //********************************************************************
        public static bool fcSISExtraerHash(String pasSistema, String pasUser)
        {
            String ClaveSaladaconHash = pasSistema;
            const int lnuCantSal = 4;

            //Extraer la sal
            byte[] claveSaladaconHashBytes = Convert.FromBase64String(ClaveSaladaconHash);
            int sal = BitConverter.ToInt32(claveSaladaconHashBytes, 0);

            //Extrae el Hash sin la sal
            byte[] claveHashBytes = new byte[claveSaladaconHashBytes.Length - lnuCantSal];
            Array.Copy(claveSaladaconHashBytes, lnuCantSal, claveHashBytes, 0, claveHashBytes.Length);

            //Combina la clave de usuario y la sal
            byte[] claveDelUsuarioBytes = Encoding.UTF8.GetBytes(pasUser);
            byte[] salero = BitConverter.GetBytes(sal);
            byte[] claveSaladaconBytes = new byte[salero.Length + claveDelUsuarioBytes.Length];
            Array.Copy(salero, 0, claveSaladaconBytes, 0, salero.Length);
            Array.Copy(claveDelUsuarioBytes, 0, claveSaladaconBytes, salero.Length, claveDelUsuarioBytes.Length);

            //Calcula el valor del Hash
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();
            byte[] claveConHash = csp.ComputeHash(claveSaladaconBytes);

            //Devuelve la clave con Hash
            for (int ixByte = 0; ixByte < claveHashBytes.Length; ixByte++)
            {
                if (claveConHash[ixByte] != claveHashBytes[ixByte])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
