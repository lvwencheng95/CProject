using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190923
{
    /// <summary>
    /// 总经理
    /// </summary>
    public class President : Approver
    {
        //初始化基类
        public President(string name)
            : base(name)
        { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else
            {
                Console.WriteLine("{0}-{1} 认为[{2}]金额过大，需经过讨论决定！！！", this.GetType().Name, Name, request.ProductName);
            }
        }
    }
}
