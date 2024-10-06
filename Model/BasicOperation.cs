using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class BasicOperation
    {
        private static List<string> saveNum = new List<string>();
        private static List<string> saveOp = new List<string>();
        private static int index = 0;


        /* 사칙연산 대상 값 저장
         * var1 > 연산자 이전 입력값
         * op > 연산자
         */
        public static void SaveValue(string var1, string op)
        {
            saveNum.Add(var1);
            saveOp.Add(op);
            index++;
            
            /*for (int i = 0; i < saveNum.Length; i++)
            {
                if (string.IsNullOrEmpty(saveNum[i]))
                {
                    saveNum[i] = var1;
                    break;
                }
            }

            for (int i = 0; i < saveOp.Length; i++)
            {
                if (string.IsNullOrEmpty(saveOp[i]))
                {
                    saveOp[i] = op;
                    break;
                }
            }*/
        }

        // 식 세팅
        public static string SetExpression()
        {
            StringBuilder expression = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                if(i > 0)
                {
                    // 첫번째 항목이 아닐 경우 항목 사이 공백 추가
                    expression.Append(" ");
                }
                if(saveNum.Count != saveOp.Count)
                {
                    saveOp.Add("=");
                }

                expression.Append($"{saveNum[i]} {saveOp[i]}");

            }
            return expression.ToString();
        }

        // 결과값 계산
        public static string Result(string var2)
        {
            saveNum.Add(var2.ToString());
            index++;

            // 먼저 곱셈과 나눗셈 처리
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "×" || saveOp[i] == "÷")
                {
                    double result = PerformOperation(saveNum[i], saveNum[i + 1], saveOp[i]);
                    saveNum[i] = result.ToString(); // 문자열로 변환하여 저장
                    saveNum.RemoveAt(i + 1);
                    saveOp.RemoveAt(i);
                    i--; // 현재 인덱스에서 다시 시작
                }
            }

            // 이제 덧셈과 뺄셈 처리
            double finalResult = double.Parse(saveNum[0]); // 첫 번째 숫자 변환
            for (int i = 0; i < saveOp.Count; i++)
            {
                finalResult = PerformOperation(finalResult.ToString(), saveNum[i + 1], saveOp[i]);
            }

            return finalResult.ToString(); // 결과 반환
        }


        private static double PerformOperation(string num1, string num2, string op)
        {
            double number1 = double.Parse(num1);
            double number2 = double.Parse(num2);
            double result = 0;

            switch (op)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "－":
                    result = number1 - number2;
                    break;
                case "×":
                    result = number1 * number2;
                    break;
                case "÷":
                    result = number1 / number2;
                    break;
            }
            return result;
        }
    }
}
