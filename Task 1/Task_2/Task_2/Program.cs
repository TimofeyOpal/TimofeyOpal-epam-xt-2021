using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Task1 task1 = new Task1();
            Console.WriteLine(task1.FirstLetterToUpper("dddd ddddddddd. dddddddd ddddddddd"));
            task1.GenLenghtStr("Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате fffdsgfgds dgfdfgdf");
            Console.Write("\n\n");
            Task2 task2 = new Task2();
            task2.GetNewString("бапп", "апвппввпавап");

            Console.Write("\n\n");
            Task3 task3 = new Task3();
            task3.GetCountWord();
            Console.Write("\n\n");
            task3.GetCountWord2();
            Console.Write("\n\n");
            Task4 task4 = new Task4();
            task4.VALIDATOR();

        }
    }
    class Task1
    {
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        public void GenLenghtStr(string a)
        {
             double sum = 0;
            string[] source = a.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double word = source.Length;
            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i].Length;
            }
            double result = sum / word;
            double result1 = Math.Floor(result);
            Console.WriteLine($"Average length is even: {result}\nAverage length is even rounding down: {result1}");


        }
    }
    class Task2
    {
        public void GetNewString(string a, string b)
        {
            var charsList = new List<char>();
            foreach (var ch in b)
            {
                if (!charsList.Contains(ch))
                {
                    charsList.Add(ch);
                }
            }

            foreach (var ch in charsList)
            {
                a = a.Replace(ch.ToString(), ch.ToString() + ch.ToString());
            }

            Console.WriteLine(a);
        }
    }
    class Task3
    {
        public void GetCountWord()
        {
            Console.Write("Ввод: ");
            string str = Console.ReadLine();
            while (str.Contains("  "))// избавляем от исключений если больше одного пробела
            {
                str = str.Replace("  ", " ");
            }
            int res = 0;
            string[] subs = str.Split(' ');
            foreach(string a in subs)
            {
                bool isUpper = char.IsUpper(a[0]);
                if (isUpper == !true)
                {
                    res++;
                }
            }
            Console.WriteLine($"Вывод {res}");
            
        }
        public void GetCountWord2()
        {
            Console.Write("Ввод: ");
            string str = Console.ReadLine();
            str = Regex.Replace(str, "[-.?!)(,:]", " ");
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            int res = 0;
            string[] subs = str.Split(' ');
            foreach (string a in subs)
            {
                bool isUpper = char.IsUpper(a[0]);
                if (isUpper == !true)
                {
                    res++;
                }
            }
            Console.WriteLine($"Вывод {res}");

        }
        
    }
    public class Task4
    {
        public void VALIDATOR()
        {
            string s = Console.ReadLine();
                bool Is = true;
                var result = new StringBuilder(s.Length);
                for (int i = 0; i < s.Length; i++)
                {
                    if (Is && char.IsLetter(s[i]))
                    {
                        result.Append(char.ToUpper(s[i]));
                        Is = false;
                    }
                    else
                        result.Append(s[i]);

                    if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                    {
                        Is = true;
                    }
                }

               Console.WriteLine(result.ToString());
            

        }
    }
    


}
