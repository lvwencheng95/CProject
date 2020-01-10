using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    public class Teacher
    {
        public string[] strStu = new string[4] { "17", "28", "39", "40" };
        //如果没有定义访问权限，默认为private
        public string name;
        //public string _name { get { return this.name;} set { this.name=value;} }
    }
}
