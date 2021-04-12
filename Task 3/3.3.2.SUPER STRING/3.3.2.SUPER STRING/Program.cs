using System;

namespace _3._3._2.SUPER_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "45465456";
            Console.WriteLine(word.Define());

        }
    }
    public static class DefineLanguage
    {
        public static string Define(this string word)
        {
            int eng = 0, rus = 0, numbers = 0, resItem ;
            char[] arrText = word.ToCharArray();         
            foreach (var item in arrText)
            {
                resItem = (int)item;
                if ((resItem >= 65) && (resItem <= 122))
                    eng++;

                else if ((resItem >= 1040) && (resItem <= 1103))
                    rus++;

                else if ((resItem >= 48) && (resItem <= 57))
                    numbers++;
                else
                {
                    break;
                }
            }
            if (rus== arrText.Length)
            {
                return "Русский";
            }
            else if (eng == arrText.Length)
            {
                return "Английский";
            }
            else if (numbers == arrText.Length)
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
