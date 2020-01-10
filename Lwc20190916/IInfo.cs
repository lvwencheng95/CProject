using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    /// <summary>
    /// 定义一个接口
    /// </summary>
    interface IInfo
    {
        //接口没有具体的实现，使用;结束
        string GetName();
        string GetAge();
    }
}
