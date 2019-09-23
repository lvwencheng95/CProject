using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190919
{
    public interface IFile
    {
        void delete();
        string getName();

        //创建文件
        void createNewFile(string name);
        //删除文件
        void deleteFile(string name);

        //返回自己类型？此处不太好理解
        IFile getIFile(int index);
    }
}
