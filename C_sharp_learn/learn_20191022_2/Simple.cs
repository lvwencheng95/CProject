using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_20191022_2
{
    public class Simple
    {
        //以下两种写法居然都可以，第二种方式超出自己的想象
        public static void ReverseAndPrint<T>(T[] arr)
        //static public void ReverseAndPrint<T>(T[] arr)
        {
            Array.Reverse(arr);
            foreach (T item in arr)
            {
                Console.Write("{0}   ",item.ToString());
            }
            Console.WriteLine();
        }
    }
}
