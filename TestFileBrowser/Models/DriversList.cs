using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFileBrowser.Models
{

    public class DriversList
    {
       public const string BaseRoot = "My computer";

        protected static List<string> root_items = new List<string>();
        public List<string> Root_Items {
            get { return root_items; }
            set { root_items = value; }
        }//Список файлов и директорий

        public string Path_dir; // путь выбранной директории

        public static List<string> Files_temp = new List<string>();

        
        public DriversList()
        {
            Path_dir = BaseRoot;
        }
        
        // Получаем список жёстких дисков
        public static List<string> GetDrives()
        {
            root_items.Clear();
            FilesCounter.Clear_Counter();
            
            var drives = DriveInfo.GetDrives().Where(_drives => _drives.DriveType == DriveType.Fixed);
                         drives.ToList().ForEach(drv =>
                            {
                                root_items.Add(@"" + drv.Name.ToString());
                            });

            return root_items;
        }

    }
}