using System;
using System.Linq;

namespace _3._3._1.SUPER_ARRAY
{


    class Program
    {


        static void Main(string[] args)
        {
            int[] a = { 5, 1, 5 };

            Func<int, int> ForceLoopDelegate = new Func<int, int>(VoidValue);

            Func<int[], int> ArrayDalegate = new Func<int[], int>(Search.SearchSum);
            ArrayDalegate += Search.MustRepeatItem;
            Console.WriteLine(ArrayDalegate.Invoke(a));
        }
        public static int VoidValue(int a)
        {
            return a;
        }
    }
    public static class LoopArray
    {
        public static int[] Loop(this int[] arr, Func<int, int> func)
        {
            if (func != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = func.Invoke(arr[i]);
                }
            }
            return arr;
        }
    }
    public static class Search
    {
        public static int SearchSum(this int[] arr)
        {
            int result = 0;
            foreach (var item in arr)
            {
                result += item;
            }
            return result;
        }
        public static int SearchMiddleValue(this int[] arr)
        {
            int result = 0, count = 0;
            foreach (var item in arr)
            {
                count++;
                result += item;
            }
            return result / count;
        }
        public static int MustRepeatItem(this int[] arr)
        {
            var groups = arr.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();
            return largest.Key;
        }


    }







}
