using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class SetExpression
    {
        public List<string> ExpNum = new List<string>();
        public List<string> ExpOp = new List<string>();
        public int index = 0;

        /* 사칙연산 대상 값 저장
         * var1 > 연산자 이전 입력값
         * op > 연산자
         */
        public void SaveValue(string var1, string op)
        {
            ExpNum.Add(var1);
            ExpOp.Add(op);
            index++;
        }

        // 식 세팅
        public string Expression()
        {
            StringBuilder expression = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                if (i > 0)
                {
                    // 첫번째 항목이 아닐 경우 항목 사이 공백 추가
                    expression.Append(" ");
                }
                if (ExpNum.Count != ExpOp.Count)
                {
                    ExpOp.Add("=");
                }

                expression.Append($"{ExpNum[i]} {ExpOp[i]}");

            }
            return expression.ToString();
        }

        // 리스트 저장 값 지우기
        public void SetClear()
        {
            ExpNum.Clear();
            ExpOp.Clear();
            index = 0;
        }

        public void AddValue(string var2)
        {
            ExpNum.Add(NumberFormat.SetFormat(var2));
            index++;
        }
    }
}
