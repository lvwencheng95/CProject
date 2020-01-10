using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    //lwc,C#中继承使用：来表示
    class CB:IInfo
    {
        public string First;
        public string Last;
        //实现接口中的方法
        public string GetName()
        {
            return First;
        }
        public string GetAge()
        {
            return Last;
        }

    }
}
