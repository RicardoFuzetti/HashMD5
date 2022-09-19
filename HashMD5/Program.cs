using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMD5
{
    internal class Program
    {
        public static void CompareHash(Dictionary<string, string> passowrdList, Dictionary<string, string> userList)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, string> users in userList)
            {
                if (passowrdList.ContainsValue(users.Value))
                {
                    Console.WriteLine($"{users.Key} -> {passowrdList.Where(x => x.Value == users.Value).FirstOrDefault().Key}");
                }
            }
        }

        public static Dictionary<string, string> UserList()
        {
            using (StreamReader file = new StreamReader(path: @"C:\Users\rick_\Desktop\HashMD5\HashMD5\users.txt"))
            {
                Dictionary<string, string> userList = new Dictionary<string, string>();
                string line = null;

                while ((line = file.ReadLine()) != null) //Lendo as linhas do arquivo
                {
                    if (!userList.ContainsKey(line.Split('-')[0])) //Verificando se o valor é duplicado
                    {
                        userList.Add(line.Split('-')[0], line.Split('-')[1]); //Salva usuário e senha
                    }
                }
                return userList;
            }
        }

        public static Dictionary<string, string> PasswordList()
        {
            using (StreamReader file = new StreamReader(path: @"C:\Users\rick_\Desktop\HashMD5\HashMD5\passwords.txt"))
            {
                Dictionary<string, string> passwordList = new Dictionary<string, string>();

                string line = null;

                while ((line = file.ReadLine()) != null) //Lendo as linhas do arquivo
                {
                    if (!passwordList.ContainsKey(line)) //Verificando se o valor é duplicado
                    {
                        passwordList.Add(line, ExtensionMD5.HashingMD5(line)); //Salva a senha normal e em HASH MD5
                    }
                }
                return passwordList;
            }
        }

        static void Main(string[] args)
        {
            CompareHash(PasswordList(), UserList());
            try
            {
                Console.WriteLine("Usuário:");
                string strUsername = Console.ReadLine();

                Console.WriteLine("Senha:");
                string strPassword = Console.ReadLine();

                Console.WriteLine("Confirme a senha:");
                string strConfPassword = Console.ReadLine();

                User objUser = new User(strUsername, strPassword, strConfPassword);
                objUser.Register();

                Console.WriteLine("Aperte qualquer botão para fechar");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
