using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMvvm.Model
{
    public class SetExpression
    {
        public List<string> expNum = new List<string>();
        public List<string> expOp = new List<string>();
        public int index = 0;

        /* 대상 값 저장
         * var1 > 연산자 이전 입력값
         * op > 연산자
         */
        public void SaveValue(string var1, string op)
        {
            expNum.Add(var1);
            expOp.Add(op);
            index++;
        }

        // 연산식 세팅
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
                if (expNum.Count != expOp.Count)
                {
                    expOp.Add("=");
                }
                if(expOp[i] == "√")
                {
                    expression.Append($"{expOp[i]} {expNum[i]}");
                }
                else
                {
                    expression.Append($"{expNum[i]} {expOp[i]}");
                }
            }
            return expression.ToString();
        }

        // 계산 완료 후 리스트 저장 값 지우기
        public void SetClear()
        {
            expNum.Clear();
            expOp.Clear();
            index = 0;
        }

        // 결과값 도출 이전 변수만 저장
        public void AddValue(string var2)
        {
            expNum.Add(NumberFormat.SetFormat(var2));
            index++;
        }
    }
}
