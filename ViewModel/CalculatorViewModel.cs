using CalMvvm.Model;
using CalMvvm.Tools;
using CalMvvm.View;
using CalMvvm.ViewModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CalMvvm
{
    public class CalculatorViewModel : OnPropertyChange
    {
        // 필드
        public HistoryViewModel HistoryVM;
        public HistoryView History;
        public Number number;
        public Calculator calculator;
        public Clear clear;

        // 속성
        private Frame historyFrame = new Frame();
        public Frame HistoryFrame
        {
            get => historyFrame;
            set
            {
                historyFrame = value;
                OnPropertyChanged(nameof(HistoryFrame));
            }
        }

        private string expression;
        public string Expression
        {
            get => expression;
            set
            {
                expression = value;
                OnPropertyChanged(nameof(Expression));
            }
        }

        private string result;
        public string Result
        {
            get
            {
                // 초기 상태일 때 0으로 세팅
                if (result == null)
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
            }
        }

        // 처음 화면 오픈 시 History 화면 안열리게함
        private Visibility historyVisibility = Visibility.Hidden;
        public Visibility HistoryVisibility
        {
            get => historyVisibility;
            set
            {
                historyVisibility = value;
                OnPropertyChanged(nameof(HistoryVisibility));
            }
        }

        // 생성자
        public CalculatorViewModel()
        {
            HistoryVM = new HistoryViewModel();
            History = new HistoryView() { DataContext = HistoryVM };
            number = new Number();
            calculator = new Calculator();
            clear = new Clear();
        }

        // 숫자 클릭
        public void OnClickNumber(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var insertNum = btn.Content.ToString();
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };

            // 계산 후 새로운 값 입력 시 기존 식 제거
            if (expression != null && (expression.Contains("=")
                || !chkOperator.Contains(expression.Substring(expression.Length - 1))))
            {
                result = "0";
                expression = null;
                OnPropertyChanged(nameof(Expression));
            }
            Result = number.InputNumber(result, insertNum);
        }

        // 계산
        public void OnClickCalculator(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };

            if(button.Content.ToString() == "x²")
            {
                button.Content = "²";
            } 

            // 연산자 입력 시 계산식에 추가
            if (expression == null || button.Content.ToString() == "√" || button.Content.ToString() == "%" 
                || button.Content.ToString() == "1/x" || button.Content.ToString() == "²")
            {
                if(button.Content.ToString() == "√")
                {
                    expression = $"{button.Content} {result}";
                }
                else
                {
                    expression = $"{result} {button.Content}";
                }
            }
            else
            {
                expression = $"{expression} {result} {button.Content}";
            }

            result = calculator.Operate(result, button.Content.ToString());
            Expression = expression;
            
            if(expression.Substring(expression.Length - 1) == "=")
            {
                Result = number.NumberFormat(result);
                HistoryVM.ExpHistory.Add(Expression + "\n" + Result);
            }
            else if(!chkOperator.Contains(expression.Substring(expression.Length - 1)))
            {
                Result = number.NumberFormat(result);
            }
            else
            {
                result = "0";
            }
        }

        // 지우기
        public void OnClickClear(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string sign = button.Content.ToString();

            if (sign == "←")
            {
                result = clear.BackSpace("0", result, expression);
                Expression = clear.BackSpace("1", result, expression);
            }
            else if (sign == "CE")
            {
                result = clear.ClearDisplay("0", result, expression);
                Expression = clear.ClearDisplay("1", result, expression);
            }
            else if (sign == "C")
            {
                result = clear.ClearAll("0");
                Expression = clear.ClearAll("1");
            }

            Result = number.NumberFormat(result);
        }

        // History 버튼 클릭 시
        public void OnClickHistory(object sender, RoutedEventArgs e)
        {
            if (HistoryVisibility == Visibility.Visible)
            {
                HistoryVisibility = Visibility.Hidden;
            }
            else
            {
                HistoryFrame.Navigate(History);
                HistoryVisibility = Visibility.Visible;
            }
        }
    }
}
