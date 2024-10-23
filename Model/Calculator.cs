using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class Calculator : AdvancedCalculator
    {
        public List<string> OperateList = new List<string>();

        /* List에 추가, 연산자에 따라 분류
         * value > 입력값
         * operate > 연산자
        */
        public string Operate(string value, string operate)
        {
            OperateList.Add(value);
            OperateList.Add(operate);
            string result = "";

            switch (operate)
            {
                case "%":
                    result = base.Percent(double.Parse(value));
                    break;
                case "1/x":
                    result = base.Franction(double.Parse(value));
                    break;
                case "²":
                    result = base.Square(double.Parse(value));
                    break;
                case "√":
                    result = base.Route(double.Parse(value));
                    break;
                case "=":
                    result = Precendence();
                    break;
            }

            return result;
        }


        // 우선순위 계산
        public string Precendence()
        {
            for (int i = 0; i < OperateList.Count; i++)
            {
                // 연산자일때
                if(i % 2 == 0)
                {
                    double var1 = double.Parse(OperateList[i].ToString());
                    if (i + 1 < OperateList.Count && OperateList[i + 1] == "×" || OperateList[i + 1] == "÷")
                    {
                        string operatorSign = OperateList[i + 1];
                        double var2 = double.Parse(OperateList[i + 2].ToString());

                        if(operatorSign == "×")
                        {
                            var1 = double.Parse(Multiply(var1, var2));
                        }
                        else if (operatorSign == "÷")
                        {
                            var1 = double.Parse(Divide(var1, var2));
                        }

                        OperateList[i] = var1.ToString();
                        OperateList.RemoveAt(i + 1);
                        OperateList.RemoveAt(i + 1);
                        i--;
                    }
                }
            }

            double finalResult = double.Parse(OperateList[0]);
            for(int i = 0; i < OperateList.Count; i++)
            {
                if(i % 2 == 1 && i * 2 - 1 < OperateList.Count )
                {
                    string operatorSign = OperateList[i * 2 - 1];
                    double var2 = double.Parse(OperateList[i + 1].ToString());
                
                    if (operatorSign == "+")
                    {
                        finalResult = double.Parse(Add(finalResult, var2));
                    }
                    else if (operatorSign == "-")
                    {
                        finalResult = double.Parse(Substract(finalResult, var2));
                    }
                }
            }
            OperateList.Clear();
            return finalResult.ToString();
        }
    }
}
