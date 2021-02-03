using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;



namespace ConsoleTest
{
    /// <summary>
    /// Класс для парсинга HTML-документа   
    /// </summary>
    class Parse
    {
        /// <summary>
        /// Метод который парсит Html документ, подсчитывать количество уникальных слов
        /// на странице и выводить статистику по словам в консоль.
        /// </summary>
        public void ParseHtml()
        {
            try
            {
                using (StreamReader sr = new StreamReader("site.html"))
                {
                    var html = "";
                    html = sr.ReadToEnd();

                    Regex regex = new Regex(@"(?:<p\w*[^>]*>(.*)</p\w*[^>]*>|<h\w*[^>]*>(.*)</h\w*[^>]*>|<div\w*[^>]*>(.*)</div\w*[^>]*>)");
                    Regex regex1 = new Regex(@"(<.*?>|<\/.*?>|&nbsp;|&quot)");
                    Dictionary<string, int> StringCount = new Dictionary<string, int>();

                    var htmlTag = regex.Matches(html);
                    foreach (Match match in htmlTag)
                    {
                        var noHtmlTag = regex1.Replace(match.Value, "");
                        string[] words = noHtmlTag.Split(' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t');
                        foreach (string s in words)
                        {
                            if (!StringCount.ContainsKey(s))
                            {
                                StringCount.Add(s, 1);
                            }

                            else
                            {
                                StringCount[s] += 1;
                            }
                        }
                    }
                    foreach (KeyValuePair<string, int> keyValue in StringCount)
                    {
                        Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
