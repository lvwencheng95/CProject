using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    class Student
    {
        string[] strStu=new string[4]{"17","28","39","40"};
        //使用快捷键prop
        public string this[int i]
        {
            get { return strStu[i]; }
            set { strStu[i] = value; }
        }
    }
}
