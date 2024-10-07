using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    class NumberFormat
    {
        // 숫자 쉼표 표시
        public static string SetFormat(string beforeNum)
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
