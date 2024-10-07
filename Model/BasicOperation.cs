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
        /*사칙연산 대상 값 저장
         * var1 > 연산자 이전 입력값
         * op > 연산자
        *//*
        public static void SaveValue(string var1, string op, ref List<string> saveNum, ref List<string> saveOp, ref int index)
        {
            saveNum.Add(var1);
            saveOp.Add(op);
            index++;
        }

        // 식 세팅
        public static string SetExpression(int index, List<string> saveNum, ref List<string> saveOp)
        {
            StringBuilder expression = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                if (i > 0)
                {
                    // 첫번째 항목이 아닐 경우 항목 사이 공백 추가
                    expression.Append(" ");
                }
                if (saveNum.Count != saveOp.Count)
                {
                    saveOp.Add("=");
                }

                expression.Append($"{saveNum[i]} {saveOp[i]}");

            }
            return expression.ToString();
        }*/

        // 결과값 계산
        public static string Result(string var2, ref List<string> saveNum, ref List<string> saveOp, ref int index)
        {
            /*Model.SetExpression.AddValue(var2);*/
            // 먼저 곱셈과 나눗셈 처리
            for (int i = 0; i < saveOp.Count; i++)
            {
                if (saveOp[i] == "×" || saveOp[i] == "÷")
                {
                    string result = PerformOperation(saveNum[i], saveNum[i + 1], saveOp[i]);
                    saveNum[i] = result.ToString(); 
                    saveNum.RemoveAt(i + 1);
                    saveOp.RemoveAt(i);
                    i--; 
                }
            }

            // 덧셈과 뺄셈 처리
            string finalResult = saveNum[0];
            for (int i = 0; i < saveOp.Count; i++)
            {
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
                    if (number2 == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다");
                        // 클리어 넣기
                        break;
                    }
                    result = (number1 / number2).ToString();
                    break;
            }
            return result;
        }

       /* // 리스트에 저장 값 지우기
        public static void setClear()
        {
            saveNum.Clear();
            saveOp.Clear();
            index = 0;
        }*/
    }
}
