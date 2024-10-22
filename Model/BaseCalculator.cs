using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class BaseCalculator
    {
        public virtual string Add(double var1, double var2)
        {
            return (var1 + var2).ToString();
        }

        public virtual string Substract(double var1, double var2)
        {
            return (var1 - var2).ToString();
        }

        public virtual string Multiply(double var1, double var2)
        {
            return (var1 * var2).ToString();
        }

        public virtual string Divide(double var1, double var2)
        {
            if(var2 == 0)
            {
                throw new DivideByZeroException("0으로 나눌 수 없습니다");
            }
            
            return (var1 / var2).ToString();
        }
    }
}
