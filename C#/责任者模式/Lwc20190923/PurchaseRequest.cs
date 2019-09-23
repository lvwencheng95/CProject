using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190923
{
    /// <summary>
    /// 采购请求(类似击鼓传花中的击鼓，何时需满足的条件)
    /// </summary>
    public class PurchaseRequest//注意每个类的访问权限，每次新建时，均为private
    {
        //金额
        public double Amount { get; set; }

        //产品名字
        public string ProductName { get; set; }

        //定义一个带参数的构造函数
        public PurchaseRequest(double amount, string productName)
        {
            this.Amount = amount;
            this.ProductName = productName;
        }
    }
}
