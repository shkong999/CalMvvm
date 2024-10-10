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

        /* 특수연산 계산
         * saveNum > 입력값
         * saveOp > 연산자
         */
        private static string SpecialOp(ref List<string> saveNum, ref List<string> saveOp)
        {
            decimal result = 0;
            for (int i = 0; i < saveOp.Count; i++)
            {
                Decimal num = decimal.Parse(saveNum[i]);
                if (saveOp[i] == "%")
                {
                    /*result = (double.Parse(saveNum[i - 1])) * (double.Parse(saveNum[i])) / 100;*/
                    result = num / 100;
                    saveOp[i] = "%";
                }
                else if(saveOp[i] == "√")
                {
                    result = (decimal)Math.Sqrt((double)num);
                }
                else if (saveOp[i] == "x²")
                {
                    result = (decimal)Math.Pow((double)num, 2);
                    saveOp[i] = "²";
                }
                else if (saveOp[i] == "1/x")
                {
                    result = num / 100;
                    saveOp[i] = "/ 100";
                }
            }
            return NumberFormat.SetFormat(result.ToString());
        }

        // ± 계산
        public static string ChangeSign(string var)
        {
            double changeSign = -double.Parse(var);
            return NumberFormat.SetFormat(changeSign.ToString());
        }
    }
}
