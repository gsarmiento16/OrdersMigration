using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OrdersMigration.Util
{
   public static  class StringExtension
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider(); //'Algorithmo TripleDES
        private static MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();// 'objeto md5
        private static string myKey = "ORDXcd23";// 'Clave secreta()

        //Funcion para el Encriptado de Cadenas de Texto
        public static string Encrypting(string text)
        {

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(text);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
            // without dashes
            .Replace("-", string.Empty)
            // make lowercase
            .ToLower();

            return encoded;

        }

    }
}
