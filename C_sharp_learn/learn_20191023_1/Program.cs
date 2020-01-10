using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learn_20191023_1
{
    /// <summary>
    /// 自定义结构体MyStructBook
    /// </summary>
    struct MyStructBook
    {
        //需要定义为public，否则无法访问  lwc,20191023
       public string bookName;
       public string bookKind;
       public double bookPrice;
    }

    enum MyEnumDay
    {
        Sun, //周日,第一个枚举符号的值是 0
        Mon, 
        tue, 
        Wed, 
        thu, 
        Fri, 
        Sat
    }

    class Program
    {
        /// <summary>
        /// 结构体的使用.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("结构体的使用");
            //结构体可不是用new的方式创建实例
            MyStructBook book1;
            MyStructBook book2;
            book1.bookName = "三体1";
            book1.bookKind = "科幻";
            book1.bookPrice =23.3;

            book2.bookName = "三体2";
            book2.bookKind = "科幻";
            book2.bookPrice = 28.3;

            Console.WriteLine(book1.bookName);
            Console.WriteLine(book1.bookKind);
            Console.WriteLine(book1.bookPrice);

            Console.WriteLine("枚举类的使用");
            //枚举类不用实例
            int i7=(int)MyEnumDay.Sun;
            int i6 = (int)MyEnumDay.Sat;
            Console.WriteLine(i7);
            Console.WriteLine(i6);

            Console.ReadKey();
        }
    }
}
