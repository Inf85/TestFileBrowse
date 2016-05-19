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
        const int SizeMin = 10 * 1024 * 1024;
        const int SizeMax = 100 * 1024 * 1024;
        const int MidSizeMin = 10 * 1024 * 1024;
        const int MidSizeMax = 50 * 1024 * 1024;

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
                            if (fInfo.Length < SizeMin)
                                small_size++;

                            if (((fInfo.Length) >= MidSizeMin) && ((fInfo.Length) <= MidSizeMax))
                                medium_size++;

                            if (fInfo.Length > SizeMax)
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