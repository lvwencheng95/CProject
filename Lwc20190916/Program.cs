using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    class Program
    {   
        //定义委托
        public delegate void ZuoCaiDelegate(int i);
        //两点比较奇怪的地方：
        //(1)可用接口来表示实现该接口类
        //(2)类实例化的方式
        static void PrintInfo(IInfo item) 
        {
            Console.WriteLine("Name:{0},Age:{1}",item.GetName(),item.GetAge());
        }

        public void abc(){
            Console.WriteLine("123");
        }
        static void Main(string[] args)
        {   
           // 示例一：接口的了解
            /*
            CA ca = new CA() { Name="TOM",Age="30"};//类实例化的方式
            CB cb = new CB() { First="JONE",Last="20"};
            PrintInfo(ca);//可用接口来表示实现该接口类的对象
            PrintInfo(cb);
            Console.WriteLine("123");
             */

            //示例二：typeof与getType的使用
            /*
            //1.使用typeof
            Type t= typeof(SomeClass);
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] me = t.GetMethods();
            foreach (FieldInfo f in fi)
            {
                Console.WriteLine(f.Name);
            }
            //遍历后不只包含自定义的方法，还包含ToString等默认方法
            foreach (MethodInfo m in me)
            {
                Console.WriteLine(m.Name);
            }
            //2.使用GetType方法
            SomeClass sc = new SomeClass();
            Console.WriteLine("sc的类型为：:"+sc.GetType());
            */

            //示例三：委托
           /*
            ZuoCai zuoCai = new ZuoCai();

            ZuoCaiDelegate zuoCaiDelegate = new ZuoCaiDelegate(zuoCai.naCai);
            //切菜
            zuoCaiDelegate += zuoCai.qieCai;//此处既然是方法，未使用()
            zuoCaiDelegate += zuoCai.caoCai;
            zuoCaiDelegate += zuoCai.shangCai;
            zuoCaiDelegate(1);//执行委托
            Console.WriteLine("完成");
            zuoCai.testString();//此处调用自定义的方法需要带有()
            */

            //示例四：数组
            /*
            int[] intArr = new int[5]{1,2,3,4,5};
            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine("使用索引查询值:"+ intArr[i]);
            }
            string[] strArr = new string[5];
            //未赋值，输出的内容为空
            foreach (string item in strArr)
            {
                Console.WriteLine(item);
            }
             */

            //示例五:索引器
            /*
            Student stu = new Student();
            Teacher tea = new Teacher();
            //tea._name = "zhangsan";       
            stu[2] = "666";
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(stu[i]);
            }
            */
            //类继承抽象类同时实现接口
            BigDoor bigDoor = new BigDoor();
            //类转换为接口后，通过接口调用类中的重写方法
            DoorAlarm doorAlarm = (DoorAlarm)bigDoor;
            doorAlarm.alerm();
            Console.ReadKey();
        }
    }
}
