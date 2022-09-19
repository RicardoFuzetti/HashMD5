using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashMD5
{
    internal class ExtensionMD5
    {
        public static string HashingMD5(string strInput)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytPassword = Encoding.ASCII.GetBytes(strInput);
            using (MD5 objMD5 = MD5.Create())
            {
                byte[] computeHash = objMD5.ComputeHash(bytPassword);
                for (int i = 0; i < computeHash.Length; i++)
                {
                    stringBuilder.Append(computeHash[i].ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
