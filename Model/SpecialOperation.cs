using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class SpecialOperation : BasicOperation
    {
        // 결과값 계산
        public string SpecialResult(ref List<string> saveNum, ref List<string> saveOp)
        {
            string finalResult = "";
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "%")
                {
                    finalResult = PerformOperation(saveNum[i], "100", saveOp[i]);
                    saveOp[i] = "%";
                }
                else if (saveOp[i] == "%")
                {
                    finalResult = PerformOperation(saveNum[i], saveNum[i], saveOp[i]);
                }
                else if (saveOp[i] == "x²")
                {
                    finalResult = PerformOperation(saveNum[i], saveNum[i], saveOp[i]);
                    saveOp[i] = "²";
                }
                else if (saveOp[i] == "1/x")
                {
                    finalResult = PerformOperation(saveNum[i], "100", saveOp[i]);
                    saveOp[i] = "/ 100";
                }
            }

            return NumberFormat.SetFormat(finalResult);
        }

        // ± 계산
        public string ChangeSign(string var)
        {
            double changeSign = -double.Parse(var);
            return NumberFormat.SetFormat(changeSign.ToString());
        }


        public override string PerformOperation(string num1, string num2, string op)
        {
            Decimal num = decimal.Parse(num1);
            Decimal result = 0;
            if (op == "%" || op == "1 / x")
            {
                result = num / 100;
            }
            else if (op == "√")
            {
                result = (decimal)Math.Sqrt((double)num);
            }
            else if(op == "x²")
            {
                result = (decimal)Math.Pow((double)num, 2);
            }

            return result.ToString();
        }
    }
}
