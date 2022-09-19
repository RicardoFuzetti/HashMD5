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
            StringBuilder stringBuilder = new StringBuilder(); //CONCATENAÇÃO NA STRING
            using (MD5 objMD5 = MD5.Create())
            {
                byte[] bytData = objMD5.ComputeHash(Encoding.ASCII.GetBytes(strInput)); //Armazena quantidade de bytes do input
                for (int i = 0; i < bytData.Length; i++)
                {
                    stringBuilder.Append(bytData[i].ToString("x2")); //Armazena em hexadecimal de 2 em 2 caracteres
                }
            }
            return stringBuilder.ToString();
        }
    }
}
