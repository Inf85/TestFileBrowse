using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFileBrowser.Models
{
    public class FileBrowse:DriversList
    {
        
        static object locker = new object();
        
        
            public FileBrowse()
            {
               Path_dir = null;
            }

        // Перебор файлов в папке включая подкаталоги

        public List<string> GetFilesinRoot(string root)
        {
            lock(locker)
            {
                if (root == "..")
                {
                    if (Files_temp.Count > 0)
                        Files_temp.Remove(Files_temp.Last());

                    if (Files_temp.Count == 0)
                    {
                        Path_dir = DriversList.BaseRoot;
                        return DriversList.GetDrives();
                    }
                    
                }
                else
                {
                    if (root.Contains(@"\"))
                         Files_temp.Add(root);
                    else
                        Files_temp.Add(root + @"\");

                }

                foreach (var _root in Files_temp)
                {
                    Path_dir += _root;
                }

                if (!Directory.Exists(Path_dir)&&(root!=".."))
                {
                    Path_dir = null;
                    Files_temp.Remove(Files_temp.Last());
                    foreach (var _no_root in Files_temp)
                    {
                        Path_dir += _no_root;
                    }
                    return root_items;
                }
                

                try
                {
                    root_items = Directory.GetDirectories(Path_dir).Select(d => Path.GetFileName(d)).ToList();
                    root_items.AddRange(Directory.GetFiles(Path_dir).Select(f => Path.GetFileName(f)));

                }
                catch { }

                finally
                {
                    FilesCounter.Clear_Counter();
                    FilesCounter.FilesSizeCount(Path_dir);
                    if (root_items != null)
                        root_items.Insert(0, "..");

                }
                return root_items;
                
            }
        }
    }
}