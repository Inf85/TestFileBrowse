using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFileBrowser.Models
{
    public class FileBrowse:DriversList
    {
        
              
            public FileBrowse()
            {
               Path_dir = null;
            }


        public void MakePathLabel() // Складываем в переменную путь текущего каталога
        {
            foreach (var _root in Root_tree)
            {
                Path_dir += _root;
            }

        }

        public void MakePath(string root) // Дерево каталогов (убираем "\\" в названии дисков)
        {
            if (root.Contains(@"\"))
                Root_tree.Add(root);
            else
                Root_tree.Add(root + @"\");
        }
        
        public List<string> RootNavigate(string root)  // Метод навигации по каталогам
        {
            if (root == "..")  //Если выбран переход на уровень вверх
            {
                if (Root_tree.Count > 0) // Убираем из пути последнюю директорию
                    Root_tree.Remove(Root_tree.Last());
                
                if (Root_tree.Count == 0)  //Если папка была корневая
                {
                     Path_dir = DriversList.BaseRoot;
                     return DriversList.GetDrives(); // Отображаем список дисков
                }

            }
            else
            {
                MakePath(root);
            }

            MakePathLabel();
            return Root_tree;
        }

        public bool IsDirectory(string path, string root) //Проверяем выбрана директория или файл
        {
            if (!Directory.Exists(Path_dir) && (root != ".."))
            {
                Path_dir = null;
                Root_tree.Remove(Root_tree.Last());
                MakePathLabel();
                return false;
            }
            return true;
        }

        // Перебор файлов в папке включая подкаталоги

        public List<string> GetFilesinRoot(string root)
        {
            this.RootNavigate(root);
            
            if (!IsDirectory(Path_dir, root))
                return null;
            else
            try
                {
                    root_items = Directory.GetDirectories(Path_dir).Select(d => Path.GetFileName(d)).ToList();
                    root_items.AddRange(Directory.GetFiles(Path_dir).Select(f => Path.GetFileName(f)));
                    root_items.Insert(0, "..");
            }
            catch { }

            finally
                {
                    FilesCounter.Clear_Counter();
                    FilesCounter.FilesSizeCount(Path_dir);

                }
          return root_items;
        }
    }
}