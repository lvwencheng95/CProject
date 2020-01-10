using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest_20190812
{
    class Test_20190814
    {
        public void typeChange()
        {
            //--------------------------------------------------------------------------
            //类型转换
            //--------------------------------------------------------------------------
            int i123 = 1;
            double d234 = i123;//较小类型往较大类型转换
            //double d345 = 5.4;
            //int i234 = d345;

            Test_20190812 t_20190812 = new Test_20190812();//派生类，继承至基类Test_date
            Test_date t_date = new Test_date();//基类
            t_date = t_20190812;
            //t_20190812 = t_date;
        }
    }
}
