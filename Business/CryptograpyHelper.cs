using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CryptograpyHelper
    {
        /// <summary>
        /// Convert string to SHA-256
        /// </summary>
        /// <param name="value">string to be convert in SHA-256</param>
        /// <returns>return SHA-256 string</returns>
        public static string ToSha256(string value)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                //DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }

    }
}
