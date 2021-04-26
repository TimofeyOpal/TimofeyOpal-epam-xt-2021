using System;
using System.IO;


namespace _4._1._1FILE_MANAGEMENT_SYSTEM
{
    public class Watcher
    {
        readonly static string homePath = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument";
        readonly static string lastLocalVersion = @"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\LastVersia";
        FileSystemWatcher watcher  = new(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument");
        string version = @$"C:\Users\MYLOCAL\Desktop\system local version\TextDocument\version";
        string time;
        string[] fileEntries;
        DirectoryInfo di;
        string _eventsNameFile;


        public Watcher()
        {
            if (Directory.Exists(homePath))
            {
                Directory.CreateDirectory(homePath);
                Console.WriteLine($"Путь к вашей рабочей дериктории: {}");
            }
            watcher = new(@"C:\Users\MYLOCAL\Desktop\system local version\TextDocument");
            CopyModernVersion();
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
            if (di != null)
            {
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }


        }




        private void CopyModernVersion()
        {

            string directory;
            time = DateTime.Now.ReplaceСolonTime();

            if (Directory.Exists(lastLocalVersion))
                Directory.Delete((lastLocalVersion), true);

            Directory.CreateDirectory(lastLocalVersion);



            foreach (var srcPath in Directory.GetFiles(homePath))
            {
                File.Copy(srcPath, srcPath.Replace(homePath, lastLocalVersion), true);
            }
            fileEntries = Directory.GetFiles(lastLocalVersion);

            for (int i = 0; i < fileEntries.Length; i++)
            {
                directory = @$"{homePath}\{File.GetLastWriteTime(fileEntries[i]).ToString().Replace(":", ",")}";
                Directory.CreateDirectory(directory);
                File.Copy(fileEntries[i], directory + "\\" + Path.GetFileName(fileEntries[i]), true);

                if (!Directory.Exists(version))
                {
                    Directory.CreateDirectory(version);
                }
                else

                    WriteLogeToFile.WriteLoge(version, time, fileEntries);

            }
            if(fileEntries.Length == 0)
            {
                WriteLogeToFile.WriteLoge(version, time, fileEntries);
            }

        }





        void OnChanged(object sender, FileSystemEventArgs e)
        {
            _eventsNameFile = Path.GetFileName(e.Name);

            time = DateTime.Now.ReplaceСolonTime();

            fileEntries = Directory.GetFiles(lastLocalVersion);

            SaveData.Save(homePath, lastLocalVersion, e);

            File.Copy(homePath + "\\" + _eventsNameFile, lastLocalVersion + "\\" + _eventsNameFile, true);


            WriteLogeToFile.WriteLoge(version, time, fileEntries);

            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Время изменения {time}");
            Console.WriteLine($"Изменен файл: {e.FullPath}");

        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            _eventsNameFile = Path.GetFileName(e.Name);
            time = DateTime.Now.ReplaceСolonTime();


            string value = $"Создан файл: {e.FullPath}";

            Console.WriteLine(value);

            SaveData.Save(homePath, lastLocalVersion, e);

            File.Copy(homePath + "\\" + _eventsNameFile, lastLocalVersion + "\\" + _eventsNameFile, true);

            di = Directory.CreateDirectory(homePath + "\\" + time);

            File.Copy(homePath + "\\" + _eventsNameFile, homePath + "\\" + time + "\\" + _eventsNameFile, true);

            fileEntries = Directory.GetFiles(lastLocalVersion);

            WriteLogeToFile.WriteLoge(version, time, fileEntries);

            Console.WriteLine($"Время изменения {time}");

        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            _eventsNameFile = Path.GetFileName(e.Name);

            time = DateTime.Now.ReplaceСolonTime();


            fileEntries = Directory.GetFiles(lastLocalVersion);

            File.Delete(lastLocalVersion + "\\" + _eventsNameFile);

            WriteLogeToFile.WriteLoge(version, time, fileEntries);

            Console.WriteLine($"Время изменения {time}  ");
            Console.WriteLine($"Удалено: {e.FullPath}");
        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {

            time = DateTime.Now.ReplaceСolonTime();

            fileEntries = Directory.GetFiles(lastLocalVersion);

            WriteLogeToFile.WriteLoge(version, time, fileEntries);

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
    static class ReplaceString
    {
        public static string ReplaceСolonTime(this DateTime time) => time.ToString().Replace(":", ",");

    }
    static class WriteLogeToFile
    {
        public static void WriteLoge(string version, string time, string[] fileEntries)
        {
            using (StreamWriter sw = File.CreateText(version + "\\" + time + ".txt"))
            {
                for (int a = 0; a < fileEntries.Length; a++)
                {
                    sw.WriteLine(File.GetLastWriteTime(fileEntries[a]).ToString().Replace(":", ","));

                }
            }
        }
    }
}