using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class Variable
    {
        // 숫자 쉼표 표시
        public static string NumberFormat(string beforeNum)
        {
            string[] dotNum;
            String afterNum;

            // 소수점이 있을 경우 앞/뒤로 자른 후 앞부분에 쉼표 표시 후 소수점 뒷자리와 합침
            if (beforeNum.Contains("."))
            {
                dotNum = beforeNum.Split(".");
                beforeNum = dotNum[0].ToString();
                afterNum = String.Format("{0:#,##0}", Double.Parse(beforeNum));
                afterNum = afterNum + "." + dotNum[1].ToString();
            }
            else
            {
                afterNum = String.Format("{0:#,##0}", Double.Parse(beforeNum));
            }

            return afterNum;
        }
        
        /* 숫자 입력할 경우 입력창 표시 체크 
        * firstNum > 기존 값
        * insertNum > 새로 입력한 값
        */
        public static string ChkNum(String firstNum, String insertNum)
        {
            // 초기상태일 경우
            if(firstNum == "0")
            {
                firstNum = insertNum;
            } 
            // 소수점이 있을 경우
            else if(firstNum.Contains("."))
            {
                // 새로 입력한 값이 소수점이 아닐 경우만 추가
                if (insertNum != ".")
                {
                    firstNum += insertNum;
                }
            }
            else
            {
                firstNum += insertNum;
            }

            return NumberFormat(firstNum);
        }
    }
}
