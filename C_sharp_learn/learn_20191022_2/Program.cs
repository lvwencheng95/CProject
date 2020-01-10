using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_20191022_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类中泛型的使用");
            //类中泛型的使用
            MyStack_1<int> myStack1 = new MyStack_1<int>();
            myStack1.Push();

            Console.WriteLine("方法中泛型的使用");
            //方法中泛型的使用
            var intArray = new int[] { 1, 2, 3, 4, 8, 5 };

            double[] dArray = { 2.4, 5.8, 8.6, 3.6 };

            //调用方式
            //确定类型
            Simple.ReverseAndPrint<int>(intArray);//调用方法

            //推断类型并调用
            Simple.ReverseAndPrint(dArray);

            Console.ReadKey();
        }
    }
}
