using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190919
{
    /// <summary>
    /// 文件类
    /// </summary>
    public class File : IFile
    {
        private string name;
        private IFile folder;
        public File(string name,IFile folder)
        {
            this.name = name;
            this.folder = folder;
        }

        public string getName() 
        {
            return name;
        }

        public void delete() 
        {
            folder.deleteFile(name);
            Console.WriteLine("---删除[" + name + "]---");
        }


        //文件不支持创建新文件
        public void createNewFile(string name)
        {
            throw new NotImplementedException();
        }
        //文件不支持创建新文件
        public void deleteFile(string name)
        {
            throw new NotImplementedException();
        }
        //文件不支持创建新文件
        public IFile getIFile(int index)
        {
            throw new NotImplementedException();
        }
    }
}
