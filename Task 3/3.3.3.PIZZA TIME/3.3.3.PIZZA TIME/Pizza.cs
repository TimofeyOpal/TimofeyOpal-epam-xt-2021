using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._3.PIZZA_TIME
{
    abstract class  Pizza
    {
        public int count { get; private set; }
        public Pizza()
        {
            this.count = count;
        }
       public abstract void CookPizza(int count);
    }
}
