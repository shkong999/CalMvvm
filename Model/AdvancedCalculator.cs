using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class AdvancedCalculator : BaseCalculator
    {
        public virtual string Percent(double var1)
        {
            Decimal result = Convert.ToDecimal(var1) / 100;
            return result.ToString();
        }

        public virtual string Franction(double var1)
        {
            Decimal result = Convert.ToDecimal(var1) / 100;
            return result.ToString();
        }

        public virtual string Square(double var1)
        {
            Decimal result = (decimal)Math.Pow((double)var1, 2);
            return result.ToString();
        }

        public virtual string Route(double var1)
        {
            Decimal result = (decimal)Math.Sqrt(var1);
            return result.ToString();
        }
    }
}
