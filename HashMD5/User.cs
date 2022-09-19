using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HashMD5
{
    public class User
    {
        public string StrUsername { get; set; }
        public string StrPassword { get; set; }
        public string StrConfPassowrd { get; set; }

        public User()
        {

        }

        public User(string strUsername, string strPassword, string strConfPassowrd)
        {
            StrUsername = strUsername;
            StrPassword = strPassword;
            StrConfPassowrd = strConfPassowrd;
        }

        public void Register()
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4}$");

            if (StrPassword == StrConfPassowrd)
            {
                if (regex.IsMatch(StrPassword))
                {
                    Console.WriteLine("Registrado");

                    //Passar diretório do arquivo
                    string strFile = @"C:\Users\rick_\Desktop\HashMD5\HashMD5\users.txt";

                    //Verifica existência do arquivo
                    if (!File.Exists(strFile))
                    {
                        //Cria o arquivo caso não exista
                        _ = File.Create(strFile);
                    }

                    //Abrindo o arquivo
                    StreamWriter objStreamWriter;

                    objStreamWriter = File.AppendText(strFile);

                    //Escrevendo
                    objStreamWriter.WriteLine(StrUsername + ";" + ExtensionMD5.HashingMD5(StrPassword));
                    objStreamWriter.Close();
                }
                else
                {
                    Console.WriteLine("Senha fora do padrão de segurança!");
                }
            }
            else
            {
                Console.WriteLine("Senhas não são iguais");
            }
        }
    }
}
