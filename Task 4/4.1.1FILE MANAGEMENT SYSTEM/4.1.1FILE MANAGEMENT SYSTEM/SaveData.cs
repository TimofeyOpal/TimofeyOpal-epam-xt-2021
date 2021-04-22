using System;
using System.IO;

namespace _4._1._1FILE_MANAGEMENT_SYSTEM
{

    public static class SaveData
    {
        public static void Save(string homePath, string lastLocalVersion, FileSystemEventArgs e)
        {
            string derictory = @$"{homePath}\{DateTime.Now.ToString().Replace(":", ",")}";
            string name;
            string searchName;
            if (e is RenamedEventArgs eventRename)
            {
                name = Path.GetFileName(eventRename.OldFullPath);
            }
            else
            {
                name = Path.GetFileName(e.Name);
            }

            Console.WriteLine(Path.GetFileName(e.Name));
            foreach (var srcPath in Directory.GetFiles(lastLocalVersion))
            {
                searchName = Path.GetFileName(srcPath);

                if (name == searchName)
                {
                    DirectoryInfo di = Directory.CreateDirectory(derictory);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    File.Move(srcPath, derictory + "\\" + name);
                }

            }
        }

    }
}
