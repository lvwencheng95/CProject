using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwc20190916
{
    class ZuoCai
    {
        #region 拿菜
        public void naCai(int i) 
        {
            Console.WriteLine("A负责拿菜" + i);
        }
        #endregion

        #region 切菜
        public void qieCai(int i) 
        {
            Console.WriteLine("B负责切菜" + i);
        }
        #endregion

        #region 炒菜
        public void caoCai(int i)
        {
            Console.WriteLine("C负责炒菜" + i);
        }
        #endregion

        #region 上菜
        public void shangCai(int i)
        {
            Console.WriteLine("D负责上菜" + i);
        }
        #endregion

        #region 测试
        public void testString()
        {
            int a = 3;
            Console.WriteLine(a);
        }
        #endregion

    }
}
