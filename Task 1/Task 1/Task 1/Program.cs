using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string s2 = "";
            Task6 d = new Task6();
            d.Interface();


        }
    }
    static class Task1
    {

        public static int CurrentSquare(int a, int b)
        {
            if ((a <= 0) | (b <= 0))
            {
                Console.WriteLine("Аргумент не может быть меньше или равен нулю");
            }
            return a * b;
        }
    }
    class Task2
    {
        public void RightTriangle(int a)
        {
            if (a <= 0)
            {
                Console.WriteLine("Аргумент не может быть меньше или равен нулю");
            }
            else
            {
                int i, j;
                for (i = 1; i <= a; i++)
                {
                    for (j = 1; j <= i; j++)
                    {
                        Console.Write('*');
                    }
                    Console.Write("\n");
                }
            };

        }
    }

    class Task3
    {
        public void Pyramid(int a)
        {

            if (a <= 0)
            {
                Console.WriteLine("Аргумент не может быть меньше или равен нулю");
            }
            else
            {
                if (a % 10 == 0)
                {
                    a = a + 1;
                }
                for (int i = 0; i < a / 2; i++)
                {
                    for (int j = 0; j < a * 2; j++)
                    {
                        if (j <= a / 2 + i && j >= a / 2 - i)
                        {
                            Console.Write("*");
                        }
                        else Console.Write(" ");
                    }
                    Console.Write("\n");
                }
            };

        }
    }
    class Task4
    {
        public void Tree(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string branch = new String('*', j);
                    Console.WriteLine(branch.PadLeft(n + 3) + "*" + branch);
                }
            }
        }
    }
    class Task5
    {
        public int SumOfNumbers(int right)
        {
            int sum = 0;
            for (int i = 0; i < right; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
    class Task6
    {
        public void Interface()
        {
            string text = "None";
            while (true)
            {
                while (text.Contains("  ")) 
                {
                    text = text.Replace("  ", " ");
                }

                text = Regex.Replace(text, @"\b([a-z])", m => m.Value.ToUpper());
                Console.WriteLine($"Параметры надписи: {text}");
                Console.Write($"    Введите:\n    1: bold\n    2: italic\n    3: underline\n");
                string v = Console.ReadLine();
                if (text == "None")
                    text = "";
                switch (v)
                {
                    case "1":
                        bool b = text.Contains("Bold");
                        if (b == true)
                        {
                            text = text.Replace("Bold", "");
                        }
                        else { text += "bold "; }
                        break;
                    case "2":
                        bool c = text.Contains("Italic");
                        if (c == true)
                        {
                            text = text.Replace("Italic", "");
                        }
                        else { text += "italic "; }
                        break;
                    case "3":
                        bool е = text.Contains("Underline");
                        if (е == true)
                        {
                            text = text.Replace("Underline", "");
                        }
                        else { text += "underline "; }
                        break;
                }
            }
        }
    }
    class Task7
    {
        public void Sort(int[] arr)
        {
            int min;
            int max;
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next();
            min = arr[0];
            max = arr[0];
            for (int n = 0; n < arr.Length; n++)
            {
                if (min > arr[n])
                {
                    min = arr[n];
                }
                if (max < arr[n])
                {
                    max = arr[n];
                }
            }
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
            Console.WriteLine($"Minimum = {min}\nMaximum = {max}\n");
            foreach (int a in arr)
            {
                Console.WriteLine(a);
            }


        }
    }
    class Task8
    {
        public static int[,,] GenerateThreedArr(int[,,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int a = 0; a < 15; a++)
                {
                    for (int b = 0; b < 20; b++)
                    {
                        arr[i, a, b] = rand.Next(-100, 100);

                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int a = 0; a < 15; a++)
                {
                    for (int b = 0; b < 20; b++)
                    {
                        if (arr[i, a, b] > 0)
                        {
                            arr[i, a, b] = 0;

                        }
                    }
                }
            }
            return arr;
            //где при выводе есть значения без минуса, посмотреть на строчку выше в конец и там он будет
        }
    }

    class Task9
    {
        public void CountSumItem(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            int res = 0;
            foreach (int a in arr)
            {
                if (a > 0)
                {
                    res += a;
                }
            }
            Console.WriteLine($"sum of positive elements: {res}");
        }
    }
    class Task10
    {
        public int SumPositiveIndexElements(int[,] arr)
        {
            int result = 0;
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    arr[i, j] = rand.Next(1, 15);

                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 0))
                    {
                        result += arr[i, j];
                    };


                }
            }
            return result;
        }
    }


}


