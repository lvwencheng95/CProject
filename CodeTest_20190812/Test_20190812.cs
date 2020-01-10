using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest_20190812
{
    class Test_20190812 :Test_date
    {
            //构造方法
            public Test_20190812(){
                string str = "123";
                //转换为数字类型
                int i1 = Convert.ToInt32(str);//16,32,64的区别
                long i2 = Int64.Parse(str);//注意返回类型
                Console.WriteLine("i1=" + i1 + ",i2=" + i2);
                //Console.ReadLine();

                //装箱与封箱
                //Object是类，而object是类型，就像String与string一样。没有区别,关键字object就是System.Object的别称
                int i = 123;
                object j = (object)i;
                int k = (int)j;
                Console.WriteLine(k);

                int p = 123;
                long m = (long)p;
                int n = (int)m;
            }

            public void learnString()
            {
                //C++中使用的赋值
                //sprintf(s.msg, (const char*)_RES("QM00S0004797"))/*拼接管理工序，全程工序途径码超长。*/;

            }
            
    }
    class Test_date
    {

    }
}
