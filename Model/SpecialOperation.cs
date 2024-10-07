using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    class SpecialOperation
    {
        public static string SpecialResult(string special, string var, ref List<string> saveNum, ref List<string> saveOp)
        {
            string result = SpecialOp(ref saveNum, ref saveOp);
            return result;
        }

        private static string SpecialOp(ref List<string> saveNum, ref List<string> saveOp)
        {
            double result = 0;
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "%")
                {
                    /*result = (double.Parse(saveNum[i - 1])) * (double.Parse(saveNum[i])) / 100;*/
                    result = (double.Parse(saveNum[i])) / 100;
                    saveOp[i] = "%";
                }
                else if(saveOp[i] == "√")
                {
                    result = Math.Sqrt(double.Parse(saveNum[i]));
                }
                else if (saveOp[i] == "x²")
                {
                    result = Math.Pow(double.Parse(saveNum[i]), 2);
                    saveOp[i] = "²";
                }
                else if (saveOp[i] == "1/x")
                {
                    result = (double.Parse(saveNum[i])) / 100;
                    saveOp[i] = "/";
                }
            }
            return NumberFormat.SetFormat(result.ToString());
        }

        public static string ChangeSign(string var)
        {
            double changeSign = -double.Parse(var);
            return NumberFormat.SetFormat(changeSign.ToString());
        }
    }
}
