using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190919
{
  /// <summary>
  /// 文件夹
  /// </summary>
  public class Folder : IFile
    {
        private string name;
        private IFile folder;//lwc，留意此处定义
        //private List<IFile> files;
        private List<IFile> files = new List<IFile>();

        public Folder(string name)
        {
            this.name = name;        
        }

        //public Folder(string name,IFile folder):base()
        public Folder(string name, IFile folder)
            : base()
        {
            this.name = name;
            this.folder = folder;
            //files = new List<IFile>();

        }

        public string getName()
        {
            return name;
        }


        public void delete()
        {
            List<IFile> del = new List<IFile>(files);
            Console.WriteLine("---------------删除子文件--------------------");
            foreach (IFile file in del)
            {
                file.delete();
            }

            Console.WriteLine("---------------删除子文件结束--------------------");
            if (folder !=null)
            {
                folder.deleteFile(name);
            }

            Console.WriteLine("-----删除["+ name + "]---");
        }

        public void createNewFile(string name)
        {
            if (name.Contains(".")) 
            {
                files.Add(new File(name,this));

            }
            else
            {
                files.Add(new Folder(name, this));
            }
            
        }

        public void deleteFile(string name)
        {
            foreach (IFile file in files)
            {
                if (file.getName().Equals(name))
                {
                    files.Remove(file);
                    break;
                }
            }
        }

        public IFile getIFile(int index)
        {
            if (0 == files.Count || index == files.Count)
            {
                return null;  
            }
            return files[index];
        }
    }
}
