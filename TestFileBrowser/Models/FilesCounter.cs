using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFileBrowser.Models
{
    public class FilesCounter
    {
        public static int small_size;  //файлы меньше 10 Мб
        public int Small_size
        {
            get { return small_size; }
            set { small_size = value; }
        }

        public static int medium_size;  //файлы больше 10 Мб меньше 50 Мб
        public int Medium_size
        {
            get { return medium_size; }
            set { medium_size = value; }
        }

        public static int large_size;  //файлы больше 100 Мб
        public int Large_size
        {
            get { return large_size; }
            set { large_size = value; }
        }


        // Обнуляем счётчики файлов
        public static void Clear_Counter()
        {
            small_size = 0;
            medium_size = 0;
            large_size = 0;
        }

        // перебор файлов в директориях и отбор по размеру
        public static void FilesSizeCount(string rootDirectory)
        {
            if (Directory.Exists(rootDirectory))
            {
                string[] directories = null;
                string[] files = null;

                try
                {
                    files = Directory.GetFiles(rootDirectory);
                }
                catch (UnauthorizedAccessException e)
                {
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                }
                if (files != null)
                {

                    foreach (var file in files)
                    {
                        try
                        {
                            FileInfo fInfo = new FileInfo(@"" + file);
                            if ((fInfo.Length / 1024 / 1024) < 10)
                                small_size++;

                            if (((fInfo.Length / 1024 / 1024) >= 10) && ((fInfo.Length / 1024 / 1024) <= 50))
                                medium_size++;

                            if ((fInfo.Length / 1024 / 1024) > 100)
                                large_size++;
                        }
                        catch {}
                            
                    }
                    directories = Directory.GetDirectories(rootDirectory);
                    foreach (var dirInfo in directories)
                    {
                        FilesSizeCount(dirInfo);
                    }
                }
            }

        }

    }
}