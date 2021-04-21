using System;
using System.IO;
using _4._1._1FILE_MANAGEMENT_SYSTEM;

namespace MyNamespace
{
    class MyClassCS
    {
        static void Main()
        {
            Console.WriteLine("Выберете режим");
            Console.WriteLine("1 = наблюдения 2 = отката изменений назад");
          
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                   new Watcher();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
   
}