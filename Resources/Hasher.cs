using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ITGadget
{
    internal class Hasher
    {
        public static string GetHash(string plainTextPW)
        {
            StringBuilder sb = new();
            byte[] textBytes = Encoding.Unicode.GetBytes(plainTextPW);
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeHash = md5.ComputeHash(textBytes);
                for (int i = 0; i < computeHash.Length; i++)
                {
                    sb.Append(computeHash[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}