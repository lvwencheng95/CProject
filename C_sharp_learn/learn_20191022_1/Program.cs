using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_20191022_1
{
    class Program
    {
        /// <summary>
        /// 示例：实现接口，同时对于as关键字的使用
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            //数组创建时，需要留意
            Animal[] animalArray = new Animal[3];

            //使用多态
            animalArray[0] = new Cat();
            animalArray[1] = new Bird();
            animalArray[2] = new Dog();

            foreach (Animal a in animalArray)
            {
                //判断是否实现ILiveBirth接口
                ILiveBirth b = a as ILiveBirth;//此处作为关键点
                if (b != null)
                {
                    Console.WriteLine("name is " + b.BabyCalled());
                }

            }

            Console.ReadKey();
        }
    }
}
