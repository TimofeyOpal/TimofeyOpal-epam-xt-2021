using MyNamespace;
using System;
using System.Collections.Generic;
using System.IO;


namespace _4._1._1FILE_MANAGEMENT_SYSTEM
{
    public class Watcher
    {
        readonly string homePath = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument";
        readonly string lastLocalVersion = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\LastVersia";
        FileSystemWatcher watcher = new(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument");
        string version = @$"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\version";
        string time;
        string[] fileEntries;
        DirectoryInfo di;



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
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

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
             fileEntries = Directory.GetFiles(lastLocalVersion);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                derictory = @$"{homePath}\{File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",")}";
                di = Directory.CreateDirectory(derictory);
                File.Copy(fileEntries[i], derictory + "\\" + Path.GetFileName(fileEntries[i]), true);

                if (!Directory.Exists(version))
                {
                    di = Directory.CreateDirectory(version);
                    using StreamWriter sw = File.CreateText(version + "\\" + DateTime.Now.ToString().Replace(":", ",") + ".txt");
                    for (int a = 0; a < fileEntries.Length; a++)
                    {
                        sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
                    }
                }

            }

        }





        void OnChanged(object sender, FileSystemEventArgs e)
        {

             time = DateTime.Now.ToString().Replace(":", ",");

            string[] fileEntries = Directory.GetFiles(lastLocalVersion);

            SaveData.Save(homePath, lastLocalVersion, e);

            File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);


            using (StreamWriter sw = File.CreateText(version + "\\" + time + ".txt"))
            {
                for (int a = 0; a < fileEntries.Length; a++)
                {
                    sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
                }
            }

            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Время изменения {time}");
            Console.WriteLine($"Изменен файл: {e.FullPath}");

        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            time = DateTime.Now.ToString().Replace(":", ","); 

            string value = $"Создан файл: {e.FullPath}";

            Console.WriteLine(value);

            SaveData.Save(homePath, lastLocalVersion, e);

            File.Copy(homePath + "\\" + Path.GetFileName(e.Name), lastLocalVersion + "\\" + Path.GetFileName(e.Name), true);

            di = Directory.CreateDirectory(homePath + "\\" + time);

            File.Copy(homePath + "\\" + Path.GetFileName(e.Name), homePath + "\\" + time + "\\" + Path.GetFileName(e.Name), true);

            string[] fileEntries = Directory.GetFiles(lastLocalVersion);

            using StreamWriter sw = File.CreateText(version + "\\" + time + ".txt");
            for (int a = 0; a < fileEntries.Length; a++)
            {
                sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
            }

            Console.WriteLine($"Время изменения {time}");

        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            

             time = DateTime.Now.ToString().Replace(":", ",");


             fileEntries = Directory.GetFiles(lastLocalVersion);

            File.Delete(lastLocalVersion + "\\" + Path.GetFileName(e.Name));

            using (StreamWriter sw = File.CreateText(version + "\\" + time + ".txt"))
            {
                for (int a = 0; a < fileEntries.Length; a++)
                {
                    sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
                }
            }

            Console.WriteLine($"Время изменения {time}  ");
            Console.WriteLine($"Удалено: {e.FullPath}");
        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {

            time = DateTime.Now.ToString().Replace(":", ",");

            fileEntries = Directory.GetFiles(lastLocalVersion);

            using (StreamWriter sw = File.CreateText(version + "\\" + time + ".txt"))
            {
                for (int a = 0; a < fileEntries.Length; a++)
                {
                    sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));
                }
            }

            SaveData.Save(homePath, lastLocalVersion, e);
            Console.WriteLine($"Время изменения {time}  ");
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
}