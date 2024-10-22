using System.Collections.Generic;

namespace CalMvvm.Model
{
    public class Clear
    {
        /*  "←" 버튼 클릭 시
         *  section > 0 (결과값에 적용) / 1 (계산식에 적용)
         *  result > 결과값
         *  expression > 계산식
         */
        public string BackSpace(string section, string result, string expression)
        {
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };
            string removeNumber = result;
            string removeExpression = "";

            if (section == "0")
            {
                // 계산식이 있을때
                if (expression != null)
                {
                    // 사칙연산으로 끝나지 않을때 (결과값 입력 후 / 특수연산 입력후 / = 으로 끝날때 )
                    if (!chkOperator.Contains(expression.Substring(expression.Length - 1)))
                    {
                        removeNumber = result;
                    }
                    //  사칙연산으로 끝날때
                    else
                    {
                        // 숫자만 있을때
                        if (result.Length == 1 || result == "0")
                        {
                            removeNumber = "0";
                        }
                        else
                        {
                            removeNumber = result.Remove(result.Length - 1);
                        }
                    }
                }
                else
                {
                    // 숫자만 있을때
                    if (result.Length == 1 || result == "0")
                    {
                        removeNumber = "0";
                    }
                    else
                    {
                        removeNumber = result.Remove(result.Length - 1);
                    }
                }
                return removeNumber;
            }
            else if(section == "1")
            {
                // 식이 있을때
                if (expression != null)
                {
                    // 사칙연산 후
                    if (chkOperator.Contains(expression.Substring(expression.Length - 1)))
                    {
                        removeExpression = expression;
                    }
                    // =  특수연산 후
                    else
                    {
                        removeExpression = "";
                    }
                }
                // 식이 없을때(숫자만 있을때)
                else
                {
                    removeExpression = expression;
                }
            }
            return removeExpression;
        }

        /*  "CE" 버튼 클릭 시
         *  section > 0 (결과값에 적용) / 1 (계산식에 적용)
         *  result > 결과값
         *  expression > 계산식
         */
        public string ClearDisplay(string section, string result, string expression)
        {
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };
            string removeNumber = result;
            string removeExpression = "";

            if (section == "0")
            {
                // 계산식이 있고
                if (expression != null)
                {
                    /* 사칙연산으로 끝나지 않거나 = 으로 끝나지 않을때 
                    * => 특수연산일때
                    */
                    if (!chkOperator.Contains(expression.Substring(expression.Length - 1))
                        || !(expression.Substring(expression.Length - 1) == "="))
                    {
                        removeNumber = "0";
                    }
                }
                return removeNumber;
            }
            else if(section == "1")
            {
                // 계산식이 있고
                if (expression != null)
                {
                    // 사칙연산으로 끝나거나 = 으로 끝나지 않을때(특수연산일때) 
                    if (chkOperator.Contains(expression.Substring(expression.Length - 1))
                        || !(expression.Substring(expression.Length - 1) == "="))
                    {
                        removeExpression = expression;
                    }
                    else
                    {
                        removeExpression = "";
                    }
                }
            }
            return removeExpression;
        }

        /*  "C" 버튼 클릭 시
         *  section > 0 (결과값에 적용) / 1 (계산식에 적용)
         *  result > 결과값
         *  expression > 계산식
         */
        public string ClearAll()
        {
            return "";
        }
    }
}
