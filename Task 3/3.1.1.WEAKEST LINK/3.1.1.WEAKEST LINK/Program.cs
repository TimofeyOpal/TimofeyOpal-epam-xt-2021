using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._1._1.WEAKEST_LINK
{
    class Program
    {
        static void Main()
        {

            FillArray();


        }
        static void FillArray()
        {
            int N;
            int men;
            Console.Write("Введите N :");
            while (!int.TryParse(Console.ReadLine(), out N));
            IEnumerable<int> person = Enumerable.Range(1, N);
            List<int> list = person.ToList();
            Console.Write("Введите, какой по счету человек будет вычеркнут каждый раунд:");
            while (!int.TryParse(Console.ReadLine(), out men));
            SortPerson<int>(list, men);
        }


        static void SortPerson<T>(List<T> arr, int c)
        {
            if (c > arr.Count)
            {
                Console.WriteLine("Невозможно вычеркнуть больше людей");
                return;
            }
            int a;
            a = arr.Count / c;
            for (int i = 0; i < a; i++)
            {
                arr.RemoveAt(arr.Count-1);
            }
            Console.WriteLine($"Осталось {arr.Count} человек");
            SortPerson<T>(arr, c);
        }



    }
}
