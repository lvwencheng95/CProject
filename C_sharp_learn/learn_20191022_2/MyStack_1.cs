using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_20191022_2
{
    //泛型的第一步，需要在类后面加上 T
    class MyStack_1<X>
    {
        int stackPointer = 0;
        //泛型的第二步，对成员变量定义为泛型
        X[] stackArray;

        /// <summary>
        /// 入栈
        /// </summary>
        public void Push()
        {
            //...
            Console.WriteLine("进栈");
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public X Pop()
        {
            X a=default(X);
            Console.WriteLine("出栈");
            //...
            return a;
        }
    }
}
