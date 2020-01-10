using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    /// <summary>
    /// 抽象类，Door 门
    /// </summary>
    public abstract class Door
    {
        //没有执行体，表示待实现的方法
        public abstract void open();//设置访问权限，否则无法实现重写
        public abstract void close();
    }
}
