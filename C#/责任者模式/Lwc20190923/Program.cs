using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190923
{
    class Program
    {
        /*
         *责任链模式类似击鼓传花，击鼓相当于设置条件，哪朵花适合。其实可以多层if-else if判断，使用责任链模式
         *有点类似递归，每次再调用相同的方法，只是传入的参数不一样。
         *
         *代码特点：
         *(1)定义抽象类，具体的经理、总经理类继承抽象类。
         *(2)设置责任链，比如经理不能决定，找总经理
         */
        static void Main(string[] args)
        {
            //当采购产品金额大于10万
            PurchaseRequest requestServer = new PurchaseRequest(120000,"服务器");
            PurchaseRequest requestComputer = new PurchaseRequest(2000,"电脑");


            Approver manager = new Manager("张山");
            Approver present = new President("李斯格");

            //设置责任链
            manager.NextApprover = present;//经理不能决定，找总经理

            //处理采购任务
            //采购服务器
            manager.ProcessRequest(requestServer);

            //采购电脑
            manager.ProcessRequest(requestComputer);

            Console.ReadLine();
        }
    }
}
