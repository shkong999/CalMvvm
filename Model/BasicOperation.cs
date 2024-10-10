using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalMvvm.Model
{
    public class BasicOperation
    {
        // 결과값 계산
        public static string Result(string var2, ref List<string> saveNum, ref List<string> saveOp, ref int index)
        {
            string result = "";
            // 먼저 곱셈과 나눗셈 처리
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "×" || saveOp[i] == "÷")
                {
                    if (saveOp[i] == "÷")
                    {
                        if (saveNum[i + 1] == "0")
                        {
                            result = "0으로 나눌 수 없습니다";
                            return result;
                        }
                    }
                    else
                    {
                        result = PerformOperation(saveNum[i], saveNum[i + 1], saveOp[i]);
                        saveNum[i] = result.ToString();
                        saveNum.RemoveAt(i + 1);
                        saveOp.RemoveAt(i);
                        i--;
                    }
                }
            }

            // 덧셈과 뺄셈 처리
            string finalResult = saveNum[0];
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "=")
                {
                    return NumberFormat.SetFormat(finalResult);
                }
                finalResult = PerformOperation(finalResult.ToString(), saveNum[i + 1], saveOp[i]);
            }

            return NumberFormat.SetFormat(finalResult);
        }


        private static string PerformOperation(string num1, string num2, string op)
        {
            double number1 = double.Parse(num1);
            double number2 = double.Parse(num2);
            string result = "";

            switch (op)
            {
                case "+":
                    result = (number1 + number2).ToString();
                    break;
                case "－":
                    result = (number1 - number2).ToString();
                    break;
                case "×":
                    result = (number1 * number2).ToString();
                    break;
                case "÷":
                    /*if (number2 == 0)
                    {
                        result = "0으로 나눌 수 없습니다";
                        break;
                    }*/
                    result = (number1 / number2).ToString();
                    break;
            }
            return result;
        }
    }
}
