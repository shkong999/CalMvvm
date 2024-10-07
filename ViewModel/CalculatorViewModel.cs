using CalMvvm.Model;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalMvvm
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /*        // 연산기호 저장
                private string op;*/

        // 계산식
        private string expression = "";
        public string Expression
        {
            get
            {
                return expression;
            }
            set
            {
                /*                // 연산자가 없는 상태일 경우
                                if (expression == "")
                                {
                                    expression = result;
                                }
                                else*/
                if (value != expression)
                {
                    expression = value;
                    OnPropertyChanged(nameof(Expression));
                }
                // 연산자 계산식에 추가 후 결과창 0으로 세팅

            }
        }

        // 결과창
        private string result = "";
        public string Result
        {
            get
            {
                // 초기 상태일 때 0으로 세팅
                if (result == "")
                {
                    result = "0";
                    return result;
                }
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
                /*if (value != result)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }*/
            }
        }

        public SetExpression SetExpress = new SetExpression();

        // 연산자 입력 시 변수만 추가
        public void AddValue(string var2)
        {
            SetExpress.ExpNum.Add(NumberFormat.SetFormat(var2));
            SetExpress.index++;
        }

        // 숫자 클릭
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var insertNum = btn.Content.ToString();

            // 계산 후 새로운 값 입력 시 기존 식 제거
            if (expression.Contains("="))
            {
                result = "0";
                expression = "";
                OnPropertyChanged(nameof(Expression));
            }

            Result = Variable.ChkNum(result, insertNum);
        }

        // 사칙연산 클릭
        public void Button_Basic(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string op = btn.Content.ToString();

            // Expression = OnPropertyChanged(nameof(Expression));

            /*BasicOperation.SaveValue(result, op, ref SetExpress.ExpNum, ref SetExpress.ExpOp, ref SetExpress.index);
            Expression = BasicOperation.SetExpression(SetExpress.index, SetExpress.ExpNum, ref SetExpress.ExpOp);*/

            SetExpress.SaveValue(result, op);
            Expression = SetExpress.Expression();

            // 사칙연산 클릭 후 입력창 0으로 세팅
            result = "0";
        }

        // 연산자(=) 클릭
        public void Button_Result(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string var2 = result.ToString();
            // 연산자 클릭 시 계산식에 변수만 추가
            AddValue(var2);
            Result = BasicOperation.Result(var2, ref SetExpress.ExpNum, ref SetExpress.ExpOp, ref SetExpress.index);
            /*Expression = BasicOperation.SetExpression(SetExpress.index, SetExpress.ExpNum, ref SetExpress.ExpOp);*/

            Expression = SetExpress.Expression();

            SetExpress.SetClear();
        }

        // 지우기 버튼 클릭
        public void Button_Clear(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string clear = btn.Content.ToString();

            // 입력창 지우기
            Result = Clear.ResultClear(clear, result);

            // 계산식 지우기
            Expression = Clear.ExpressionClear(clear, expression);
            SetExpress.SetClear();
        }

        // 특수연산 
        public void Button_Special(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string special = btn.Content.ToString();
            string insertNum = result;

            SetExpress.SaveValue(result, special);

            Result = SpecialOperation.SpecialResult(special, insertNum, ref SetExpress.ExpNum, ref SetExpress.ExpOp);
            Expression = SetExpress.Expression();
            /*Result = SpecialOperation.SpecialResult(special, insertNum);*/
        }

        // ± 클릭시
        public void Button_Special2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string insertNum = result;

            Result = SpecialOperation.ChangeSign(insertNum);
        }
    }
}
