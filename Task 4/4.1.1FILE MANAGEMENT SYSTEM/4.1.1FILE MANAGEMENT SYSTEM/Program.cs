using System;
using System.IO;

namespace MyNamespace
{
    class MyClassCS
    {
        static void Main()
        {
            Console.WriteLine(File.GetLastWriteTime(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\Новый текстовый документ.txt"));
            Console.WriteLine(File.GetCreationTime(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\Новый текстовый документ.txt"));



            Watcher watcher;
            Console.WriteLine("Выберете режим");
            Console.WriteLine("1 = наблюдения 2 = отката изменений назад");

            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    watcher = new Watcher();

                    break;
                default:
                    break;
            }





            // Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }





    }

    public class Watcher
    {
        readonly string homePath = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument";
        readonly string lastLocalVersion = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\LastVersia";
        // static string derictory = @$"{homePath}\{DateTime.Now.ToString().Replace(":", ",")}";
        FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument");

        public Watcher()
        {
            LastVersion();
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security;
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;

        }




        private void LastVersion()
        {

            string derictory;
            if (!Directory.Exists(lastLocalVersion))
            {
                Directory.CreateDirectory(lastLocalVersion);
            }

            foreach (var srcPath in Directory.GetFiles(homePath))
            {
                File.Copy(srcPath, srcPath.Replace(homePath, lastLocalVersion), true);
            }
            string[] fileEntries = Directory.GetFiles(lastLocalVersion);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                derictory = @$"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\{File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",")}";
                Directory.CreateDirectory(derictory);
                File.Copy(fileEntries[i], derictory + "\\" + Path.GetFileName(fileEntries[i]), true);
                using (StreamWriter sw = File.CreateText(derictory + "\\" + File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",") + ".txt"))
                {
                    for (int a = 0; a < fileEntries.Length; a++)
                    {
                        if (a != i)
                        {
                            sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
                            Console.WriteLine();
                        }
                    }
                }
            }



        }


        void OnChanged(object sender, FileSystemEventArgs e)
        {
            SaveData.Save(homePath, lastLocalVersion, e);
            File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);

            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Время изменения {DateTime.Now}  ");
            Console.WriteLine($"Изменен файл: {e.FullPath}");

        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            //  File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);
            Console.WriteLine($"Время изменения {DateTime.Now}  ");
            string value = $"Создан файл: {e.FullPath}";
            Console.WriteLine(value);
            SaveData.Save(homePath, lastLocalVersion, e);
            File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);



            //string[] fileEntries = Directory.GetFiles(homePath);
            //for (int i = 0; i < fileEntries.Length; i++)
            //  {
            //  string  derictory = @$"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\{File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",")}";
            //  Directory.CreateDirectory(derictory);
            //   
            //   using (StreamWriter sw = File.CreateText(derictory + "\\" + File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",") + ".txt"))
            //   {
            //        for (int a = 0; a < fileEntries.Length; a++)
            //       {
            //            if (a != i)
            //           {
            //               sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
            //              Console.WriteLine();
            //           }
            //       }
            //    }
            //  }


        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            SaveData.Save(homePath, lastLocalVersion, e);
            File.Delete(lastLocalVersion + "\\" + Path.GetFileName(e.Name));

            Console.WriteLine($"Время изменения {DateTime.Now}  ");
            Console.WriteLine($"Удалено: {e.FullPath}");
        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            SaveData.SaveRenamedFile(homePath, lastLocalVersion, e);
            // File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);
            Console.WriteLine($"Время изменения {DateTime.Now}  ");
            Console.WriteLine($"Переименовано:");
            Console.WriteLine($"    Старое название: {e.OldFullPath}");
            Console.WriteLine($"    Новое название: {e.FullPath}");
        }

        private void OnError(object sender, ErrorEventArgs e) =>
           PrintException(e.GetException());

        private void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }



    public static class SaveData
    {
        public static void Save(string homePath, string lastLocalVersion, FileSystemEventArgs e)
        {
            string derictory = @$"{homePath}\{DateTime.Now.ToString().Replace(":", ",")}";
            string name = Path.GetFileName(e.Name);
            string searchName;

            Console.WriteLine(Path.GetFileName(e.Name));
            foreach (var srcPath in Directory.GetFiles(lastLocalVersion))
            {
                searchName = Path.GetFileName(srcPath);

                if (name == searchName)
                {
                    Directory.CreateDirectory(derictory);
                    //TODO: запечать пак
                    File.Move(srcPath, derictory + "\\" + name);
                }

            }
        }

        public static void SaveRenamedFile(string homePath, string lastLocalVersion, RenamedEventArgs e)
        {
            string derictory = @$"{homePath}\{DateTime.Now.ToString().Replace(":", ",")}";
            string name = Path.GetFileName(e.OldFullPath);
            string searchName;

            Console.WriteLine(Path.GetFileName(e.Name));
            foreach (var srcPath in Directory.GetFiles(lastLocalVersion))
            {
                searchName = Path.GetFileName(srcPath);

                if (name == searchName)
                {
                    Directory.CreateDirectory(derictory);
                    //TODO: запечать пак
                    File.Move(srcPath, derictory + "\\" + name);
                }

            }
        }
    }

}