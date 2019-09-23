using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190923
{
    /// <summary>
    /// 经理
    /// </summary>
    public class Manager : Approver
    {
        //初始化基类
        public Manager(string name)
            : base(name)
        { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 10000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
