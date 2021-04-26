using _4._1._1FILE_MANAGEMENT_SYSTEM;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyNamespace
{
    class MyClassCS
    {
        static void Main()
        {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Ushgjhfjhgers\MYLOCghjgjhgjhAL\Desktghjhjghgjop\shjghjjhgstem local veghjgjhhgjrsion\TexjhgjhgjhtDocument");

            Console.WriteLine("Выберете режим");
            Console.WriteLine("1 = наблюдения 2 = отката изменений назад");

            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    new Watcher();
                    break;
                case "2":
                    new Rollback();
                    break;

                default:
                    break;
            }

            Console.ReadLine();
        }
    }

    



}