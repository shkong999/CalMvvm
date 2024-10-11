using System.Collections.Generic;

namespace CalMvvm.Model
{
    class Clear
    {
        // 입력창 지우기
        public static string ResultClear(string clear, string result, string expression)
        {
            string removeNum = "0";
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };

            /*removeNum = result;*/

            if (clear == "←")
            {
                // 계산식이 있을때
                if (expression != "")
                {
                    // 사칙연산으로 끝나지 않을때 (결과값 입력 후 / 특수연산 입력후 / = 으로 끝날때 )
                    if (!chkOperator.Contains(expression.Substring(expression.Length - 1)))
                    {
                        removeNum = result;
                    }
                    //  사칙연산으로 끝날때
                    else
                    /*else if (expression.Substring(expression.Length - 1) == "=")*/
                    {
                        // 숫자만 있을때
                        if (result.Length == 1 || result == "0")
                        {
                            removeNum = "0";
                        }
                        else
                        {
                            removeNum = result.Remove(result.Length - 1);
                        }
                    }
                }
                else
                {
                    // 숫자만 있을때
                    if (result.Length == 1 || result == "0")
                    {
                        removeNum = "0";
                    }
                    else
                    {
                        removeNum = result.Remove(result.Length - 1);
                    }

                }
            }
            else if (clear == "C")
            {
                removeNum = "";
            }
            else if (clear == "CE")
            {
                // 계산식이 있고
                if (expression != "")
                {
                    /* 사칙연산으로 끝나지 않거나 = 으로 끝나지 않을때 
                    * => 특수연산일때
                    */
                    if (!chkOperator.Contains(expression.Substring(expression.Length - 1))
                        || !(expression.Substring(expression.Length - 1) == "="))
                    {
                        removeNum = "0";
                    }
                }
            }
            return NumberFormat.SetFormat(removeNum);
        }

        // 계산식 지우기
        public static string ExpressionClear(string clear, string expression)
        {
            string removeExp = "";
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };

            if(clear == "←")
            {   
                // 식이 있을때
                if(expression != "")
                {
                    // 사칙연산 후
                    if (chkOperator.Contains(expression.Substring(expression.Length - 1)))
                    {
                        removeExp = expression;
                    }
                    // = / 특수연산 후
                    else
                    {
                        removeExp = "";
                    }
                }
                // 식이 없을때(숫자만 있을때)
                else
                {
                    removeExp = expression;
                }
            }
            else if (clear == "C")
            {
                removeExp = "";
            }
            else if (clear == "CE")
            {
                // 계산식이 있고
                if (expression != "")
                {
                    // 사칙연산으로 끝나거나 = 으로 끝나지 않을때(특수연산일때) 
                    if (chkOperator.Contains(expression.Substring(expression.Length - 1))
                        || !(expression.Substring(expression.Length - 1) == "="))
                     {
                        removeExp = expression;
                    }
                    else
                    {
                        removeExp = "";
                    }
                }
            }
            /* switch (clear)
            {
                case "←":
                    if (expression.Contains("="))
                    {
                        removeExp = "";
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "C":
                    removeExp = "";
                    break;
                case "CE":
                    if (!expression.Contains("="))
                    {
                        removeExp = expression;
                        break;
                    }
                    else
                    {
                        removeExp = "";
                        break;
                    }
            }*/
           
            return removeExp;
        }
    }
}
