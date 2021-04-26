using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1._1FILE_MANAGEMENT_SYSTEM
{
    class Rollback
    {
        readonly string version = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\version";
        readonly string home = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument";
        private List<string> listVersion = new();
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
                if (nameVersia == listVersion[i])
                {
                    GetVersia(nameVersia);
                }
                else Console.WriteLine("Такой версии не найдено");
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
                    DirectoryInfo info = new(item);
                    if (readText[i] == info.Name)
                    {
                        string[] filе = Directory.GetFiles(item);
                        foreach (var itemInside in filе)
                        {
                            File.Copy(itemInside, home + "\\" + Path.GetFileName(itemInside));
                        }
                    }
                }
                Console.WriteLine("Все успешно!");
            }
        }
    }
}
