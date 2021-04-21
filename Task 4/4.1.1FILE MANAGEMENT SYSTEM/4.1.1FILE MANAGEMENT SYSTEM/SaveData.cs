using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1._1FILE_MANAGEMENT_SYSTEM
{
    
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
                        DirectoryInfo di = Directory.CreateDirectory(derictory);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        File.Move(srcPath, derictory + "\\" + name);
                    }

                }
            }
        
    }
}
