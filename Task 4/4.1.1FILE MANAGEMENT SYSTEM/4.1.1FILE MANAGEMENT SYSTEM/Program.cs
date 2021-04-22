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

    class Rollback
    {
        string version = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\version";
        string home = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument";
        List<string> listVersion = new List<string>();
        string name;
        public Rollback()
        {
            GetNameVersion();
            RequestToVersia();
        }

        public void GetNameVersion()
        {
            var files = Directory.GetFiles(version);
            for (int i = 0; i < files.Length; i++)
            {
                name = Path.GetFileName(files[i]);
                name = name.Remove(name.Length - 4);
                listVersion.Add(name);
                Console.WriteLine(name);
            }
        }
        public void RequestToVersia()
        {
            Console.WriteLine("Введите имя нужно вам версии:");
            string nameVersia = Console.ReadLine();
            for (int i = 0; i < listVersion.Count; i++)
            {
                if(nameVersia == listVersion[i])
                {
                    GetVersia(nameVersia);
                }
            }

        }

        private void GetVersia(string name)
        {
            var arrPath = Directory.GetDirectories(home);
            string[] readText = default;
            var files = Directory.GetFiles(version);
            for (int i = 0; i < files.Length; i++)
            {
                string nameSearchFile = Path.GetFileName(files[i]);
                nameSearchFile = nameSearchFile.Remove(nameSearchFile.Length - 4);
                if (nameSearchFile == name)
                {
                     readText = File.ReadAllLines(files[i]);

                    string[] Deletefiles = Directory.GetFiles(home, "*.txt");
                    foreach (string file in Deletefiles)
                    {
                        File.Delete(file);
                   }
                    break;
                }
            }
            for (int i = 0; i < readText.Length; i++)
            {
                foreach (var item in arrPath)
                {
                    DirectoryInfo info = new DirectoryInfo(item);
                    if (readText[i] == info.Name)
                    {
                        string[] filе = Directory.GetFiles(item);
                        foreach (var itemInside in filе)
                        {
                            File.Copy(itemInside, home+"\\"+ Path.GetFileName(itemInside));
                        }
                    }
                }
                Console.WriteLine("Все успешно!");
            }
        }





    }



}