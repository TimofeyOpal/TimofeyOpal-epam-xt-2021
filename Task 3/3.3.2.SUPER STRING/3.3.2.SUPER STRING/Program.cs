using System;

namespace _3._3._2.SUPER_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "4546ff5456";
            Console.WriteLine(word.Define());

        }
    }
    public static class DefineLanguage
    {
        public static string Define(this string word)
        {
            int resItem = 0;
            char[] arrText = word.ToCharArray();
            var arrRus = new System.Collections.Generic.List<bool>();
            var arrEng = new System.Collections.Generic.List<bool>();
            var arrNumbers = new System.Collections.Generic.List<bool>();
            foreach (var item in arrText)
            {
                resItem = (int)item;
                if ((resItem >= 65) && (resItem <= 122))
                    arrEng.Add(true);

                else if ((resItem >= 1040) && (resItem <= 1103))
                     arrRus.Add(true);

                else if ((resItem >= 48) && (resItem <= 57))
                     arrNumbers.Add(true);
                else
                {
                    break;
                }
            }

            if (arrRus.Count == arrText.Length)
            {
                return "Русский";
            }
            else if (arrEng.Count == arrText.Length)
            {
                return "Английский";
            }
            else if (arrNumbers.Count == arrText.Length)
            {
                return "Числа";
            }
            else
            {
                return "Смешанный";
            }
        }
    }

}
