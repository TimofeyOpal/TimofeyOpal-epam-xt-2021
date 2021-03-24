using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._1._2.TEXT_ANALYSIS
{
    class Program
    {
        static void Main(string[] args)
        {         
            CountText text = new CountText("");
            text.Sort();
            text.SortDesc();
        }
    }

    public static class Punctuation
    {
        public static string Delete(this string text)
        {
            var sb = new StringBuilder();

            foreach (char c in text)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
        public static string[] GetArrString(string text)
        {
            char[] separators = new char[] { ' ', '=', '+', '-', '*', '/' };
            string[] wordsArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return wordsArray;
        }
        public static string[] FirstLetterToUpper(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                string text = str[i];
                text = char.ToUpper(text[0]) + text[1..].ToLower();
                str[i] = text;
            }
            return str;
        }
    }

    class CountText
    {
        int count;
        private string[] _text;
        Dictionary<string, int> openWith = new Dictionary<string, int>();
        public CountText(string text)
        {
            Punctuation.Delete(text);
            string[] textArr = Punctuation.GetArrString(text);
            _text = Punctuation.FirstLetterToUpper(textArr);
            Adding();
        }
        void Adding()
        {
            foreach (var item in _text)
            {
                if (!openWith.ContainsKey(item)) 
                {
                    count = 0;
                    foreach (var element in _text)
                    {
                        if (item == element)
                        {
                            count++;
                        }                      
                    }
                    openWith.Add(item, count);
                }                              
            }
        }
        public void ddd()
        {
            foreach (var item in openWith)
            {
                Console.WriteLine($"Ключ {item.Key} значение {item.Value}");
            }
        }
        public void Sort()
        {
            openWith = openWith.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in openWith)
            {
                Console.WriteLine($"Ключ {item.Key} значение {item.Value}");
            }
        }

        public void SortDesc()
        {
            var item = openWith.OrderByDescending(r => r.Value).ThenBy(r => r.Key);
            foreach (var itemd in item)
            {
                Console.WriteLine($"Ключ {itemd.Key} значение {itemd.Value}");
            }
        }
    }
}
