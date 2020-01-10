using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    class CA:IInfo
    {
        public string Name;
        public string Age;
        //实现接口中的方法
        public string GetName()
        {
            return Name;
        }
        public string GetAge()
        {
            return Age;
        }
    }
}
