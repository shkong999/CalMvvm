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

        // 연산기호 저장
        private string op;

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
                if (value != result)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        // 숫자 클릭
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var insertNum = btn.Content.ToString();

            if (op != null)
            {
                Result = "0";
            }

            Result = Variable.ChkNum(result, insertNum);
        }

        // 사칙연산 클릭
        public void Button_Basic(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            op = btn.Content.ToString();

            // Expression = OnPropertyChanged(nameof(Expression));

            BasicOperation.SaveValue(result, op);
            Expression = BasicOperation.SetExpression();
        }

        // 연산자(=) 클릭
        public void Button_Result(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string var2 = result.ToString();

            
            // 입력값(result)를 넘겨준다
            Result = BasicOperation.Result(var2);
            Expression = BasicOperation.SetExpression();
        } 
    }
}
