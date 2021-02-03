using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkBack workBack = new WorkBack();
            Parse parse = new Parse();
            Console.WriteLine("Введите URL адресс");
            string urlAdress = Console.ReadLine();
            workBack.SaveFile(urlAdress);
            parse.ParseHtml();           
            
            Console.ReadLine();




        }


    }


        
           
            

        
    
}
