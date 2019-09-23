using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190919
{
    class Program
    {
        static void Main(string[] args)
        {
            //涉及模式的学习
            //示例:组合模式
            //example 1
            /*
              * 涉及接口以及类：IFile(接口)、File、Folder 
             */
            //根目录
            IFile root = new Folder("我的电脑");
            //分盘
            root.createNewFile("c盘");
            root.createNewFile("d盘");
            root.createNewFile("E盘");
            //获取d盘
	        IFile D = root.getIFile(1);
            //d盘下创建文件夹
	        D.createNewFile("project");
	        D.createNewFile("电影");
            //获取名称为"project"的文件夹
	        IFile project = D.getIFile(0);
            //在名称为"project"的文件夹下创建文件
	        project.createNewFile("test1.java");
	        project.createNewFile("test2.java");
	        project.createNewFile("test3.java");
            //获取名称为"电影"的文件夹
	        IFile movie = D.getIFile(1);
            //在名称为"电影"的文件夹下创建文件
	        movie.createNewFile("致青春.avi");
	        movie.createNewFile("速度与激情6.avi");
	        
	        /* 以上为当前文件系统的情况，下面我们尝试删除文件和文件夹 */
	        display(null, root);
	        Console.WriteLine();
	        
	        project.delete();
	        movie.getIFile(1).delete();

            Console.WriteLine();
            display(null, root);

            display(null, root);
            Console.WriteLine();
            //display(null, root);
            /*
           //example 2
             /*
              * 涉及接口以及类：Graphics(抽象类)、Circle、Line、ComplexGrapics 
             */
            /*
           //复杂图形1，包含一个复杂图形2，且带有两条线
           ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
           complexGraphics.Add(new Line("线段A"));

           //复杂图形2
           ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
           CompositeCG.Add(new Circle("圆1"));
           CompositeCG.Add(new Line("线段B"));

           complexGraphics.Add(CompositeCG);
           Line line = new Line("线段C");
           complexGraphics.Add(line);

           // 显示复杂图形的画法
           Console.WriteLine("复杂图形的绘制如下：");
           Console.WriteLine("---------------------");
           //复杂图形1
           complexGraphics.Draw();
           Console.WriteLine("复杂图形绘制完成");
           Console.WriteLine("---------------------");
           Console.WriteLine();

           // 移除一个组件再显示复杂图形的画法
           complexGraphics.Remove(line);
           Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
           Console.WriteLine("---------------------");
           complexGraphics.Draw();
           Console.WriteLine("复杂图形绘制完成");
           Console.WriteLine("---------------------");
           Console.ReadKey();
           */
        }
        
        public static void display(string prefix, IFile file)
        {
            if (prefix == null)
            {
                prefix = "";
            }
            Console.WriteLine(prefix + file.getName());
            if (file is Folder)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        //Console.WriteLine("i的值 "+ i);
                        if (file.getIFile(i) != null)
                        {
                            display(prefix + "--", file.getIFile(i));
                        }
                        else
                        {
                            //优化下，根据是否为空，来决定是否退出循环
                            break;
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                        break;
                    }
                }
            }
        }
    }
}
