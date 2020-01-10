using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    class BigDoor:Door,DoorAlarm
    {

        public void alerm()
        {
            Console.WriteLine("实现接口，重写方法，响铃");
        }

        public override void open()
        {
            Console.WriteLine("继承抽象类，重写方法，开门");
        }

        public override void close()
        {
            Console.WriteLine("继承抽象类，重写方法，关门");
        }
    }
}
