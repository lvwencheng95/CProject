using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190923
{
    /// <summary>
    /// 审核者
    /// </summary>
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }

        public Approver(string name)
        {
            this.Name = name;
        }

        //抽象方法，定义处理采购这件时间采取措施，能处理or让其它人处理
        public abstract void ProcessRequest(PurchaseRequest request);
    }
}
