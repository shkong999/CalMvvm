using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class Number
    {
        /* 숫자 입력할 경우 입력창 표시 체크 
        * existingValue > 기존 값
        * insertNum > 새로 입력한 값
        */
        public string InputNumber(String existingValue, String insertNum)
        {
            // 초기상태일 경우
            if (existingValue == "0")
            {
                if (insertNum == ".")
                {
                    existingValue += insertNum;
                }
                else
                {
                    existingValue = insertNum;
                }
            }
            // 소수점이 있을 경우
            else if (existingValue.Contains("."))
            {
                // 새로 입력한 값이 소수점이 아닐 경우만 추가
                if (insertNum != ".")
                {
                    existingValue += insertNum;
                }
            }
            else
            {
                existingValue += insertNum;
            }

            return NumberFormat(existingValue);
        }

        // 숫자 쉼표 표시
        public string NumberFormat(string beforeNum)
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
                if (Double.TryParse(beforeNum, out double d))
                {
                    afterNum = String.Format("{0:#,##0}", Double.Parse(beforeNum));
                }
                else
                {
                    return beforeNum;
                }
            }
            return afterNum;
        }
    }
}
