using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_20191022_1
{
    class Cat :Animal,ILiveBirth
    {
        public string BabyCalled()
        {
            return "kitten";
        }
    }
}
