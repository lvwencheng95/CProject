using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190919
{
    /// <summary>
    /// 线
    /// </summary>
   public class Line :Graphics
    {
       //：base表示调用基类的构造函数，即Graphics的构造方法
        public Line(string name)
            : base(name)
        { }

        //// 重写父类抽象方法
        //public override void Draw()
        //{
        //    Console.WriteLine("画  " + Name);
        //}
        //// 因为简单图形在添加或移除其他图形，所以简单图形Add或Remove方法没有任何意义
        //// 如果客户端调用了简单图形的Add或Remove方法将会在运行时抛出异常
        //// 我们可以在客户端捕获该类移除并处理
        //public override void Add(Graphics g)
        //{
        //    throw new Exception("不能向简单图形Line添加其他图形");
        //}
        //public override void Remove(Graphics g)
        //{
        //    throw new Exception("不能向简单图形Line移除其他图形");
        //}

        public override void Draw()
        {
            Console.WriteLine("线：画  " + Name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Line添加其他图形");
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Line移除其他图形");
        }
    }
}
