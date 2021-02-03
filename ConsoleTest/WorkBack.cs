using System;
using System.IO;
using System.Net;
using System.Text;


namespace ConsoleTest
{
    class WorkBack
    {
        WebClient wc = new WebClient();

        /// <summary>
        /// Метод приложения который считывает введенный Url-adress, скачивает HTML-страницу посредством HTTP-запроса и сохраняет ее на жесткий диск.         
        /// </summary>
        /// <param name="urlAdress"> 
        /// Аргументы, передаваемые в качестве параметров
        /// при вызове приложения из консоли с аргументами. 
        /// </param>
        public void SaveFile(string urlAdress)
        {
            wc.Encoding = Encoding.UTF8;
            try
            {
                string answer = wc.DownloadString(urlAdress);


                if (File.Exists("site.html"))
                {
                    using (StreamWriter sw = new StreamWriter("site.html", false))
                    {
                        sw.WriteLine(answer);
                    }
                    Console.WriteLine("Запись выполнена");

                }
                else
                {
                    File.Create("site.html").Close();
                    using (StreamWriter sw = new StreamWriter("site.html", false))
                    {
                        sw.WriteLine(answer);
                    }
                    Console.WriteLine("Запись выполнена");
                }
            }               
            catch (Exception e)
            {
                if (File.Exists("Log.txt"))
                {
                    using (StreamWriter sw = new StreamWriter("Log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString()},  {e.Message}");
                    }
                   

                }
                else
                {
                    File.Create("Log.txt").Close();
                    using (StreamWriter sw = new StreamWriter("Log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString()},  {e.Message}");
                    }
                    
                }
                Console.WriteLine(e.Message);
            }
        }

    }
}
