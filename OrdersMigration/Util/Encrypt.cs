using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OrdersMigration.Util
{
    public class Encrypt
    {
        public TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider(); //'Algorithmo TripleDES
        public MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();// 'objeto md5
        private string myKey = "ORDXcd23";// 'Clave secreta()

        //Funcion para el Encriptado de Cadenas de Texto
        public string EncryptingPassword(string password)
        {

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

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

        public string DecrypString(string text)
        {
            string valor = string.Empty;

            if (text.Trim() == string.Empty) {
                valor = string.Empty;
            } else {

                try
                {
                    des.Key = hashmd5.ComputeHash(new UnicodeEncoding().GetBytes(myKey));
                    des.Mode = CipherMode.ECB;
                    ICryptoTransform desencrypta = des.CreateDecryptor();
                    Byte[] buff = Convert.FromBase64String(text);
                    valor = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length));
                } catch (Exception e)
                { 
                   
                 }
            }
            return valor;
        }
    }
}
