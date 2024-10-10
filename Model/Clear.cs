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

            if (clear == "←")
            {
                removeNum = result;
                //if(expression != "")
                //{
                //    // 계산이 끝나지 않았을 경우
                //    if (chkOperator.Contains(expression.Substring(expression.Length - 1)))
                //    {
                //        if (result.Length == 1 || result == "0")
                //        {
                //            removeNum = "0";
                //        }
                //        else
                //        {
                //            removeNum = result.Remove(result.Length - 1);
                //        }
                //    }
                //    else
                //    {
                //        removeNum = result;
                //    }
                //}
                //else
                //{
                //    if (result.Length == 1 || result == "0")
                //    {
                //        removeNum = "0";
                //    }
                //    else
                //    {
                //        removeNum = result.Remove(result.Length - 1);
                //    }
                //}
                ///*if (expression != null)
                //{
                //    if (!expression.Contains("="))
                //    {
                //        if (result.Length == 0 || result == "0")
                //        {
                //            removeNum = "0";
                //        }
                //        else
                //        {
                //            removeNum = result.Remove(result.Length - 1);
                //        }
                //    }
                //    else
                //    {
                //        removeNum = result;
                //    }
                //}
                //else
                //{
                //    if (result.Length == 1 || result == "0")
                //    {
                //        removeNum = "0";
                //    }
                //    else
                //    {
                //        removeNum = result.Remove(result.Length - 1);
                //    }
                //}*/
            }
            else
            {
                removeNum = "0";
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
                if(expression != "")
                {
                    if (chkOperator.Contains(expression.Substring(expression.Length - 1)))
                    {
                        removeExp = "";
                    }
                }
                else
                {
                    removeExp = expression;
                }
            }
            
            switch (clear)
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
            }
            return removeExp;
        }

    }
}
