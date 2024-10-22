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

        // List에 추가, 숫자와 연산기호 분리
        public string Operate(string value, string operate)
        {
            OperateList.Add(value);
            OperateList.Add(operate);

            /*if(operate == "=")
            {
                return Precendence()
            }*/
            return value;
        }

        /*
        // 우선순위 계산
        public string Precendence()
        {


        }*/
    }
}
