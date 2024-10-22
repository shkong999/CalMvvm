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
        public HistoryViewModel HistoryVM;
        public HistoryView History;

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
                if (value != expression)
                {
                    expression = value;
                    OnPropertyChanged(nameof(Expression));
                }
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
            }
        }

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

        public SetExpression SetExpress = new SetExpression();
        public SpecialOperation specialOperation = new SpecialOperation();
        public BasicOperation basicOperation = new BasicOperation();

        public CalculatorViewModel()
        {
            HistoryVM = new HistoryViewModel();
            History = new HistoryView() { DataContext = HistoryVM };
        }

        // 숫자 클릭
        public void OnClickNumber(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var insertNum = btn.Content.ToString();
            var chkOperator = new HashSet<string> { "+", "－", "×", "÷" };

            // 계산 후 새로운 값 입력 시 기존 식 제거
            if (expression != "" && (expression.Contains("=") 
                || !chkOperator.Contains(expression.Substring(expression.Length - 1))) )
            {
                result = "0";
                expression = "";
                OnPropertyChanged(nameof(Expression));
            }

            Result = Variable.ChkNum(result, insertNum);
        }

        // 사칙연산 클릭
        public void OnClickBasic(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string op = btn.Content.ToString();

            SetExpress.SaveValue(result, op);
            Expression = SetExpress.Expression();

            // 사칙연산 클릭 후 입력창 0으로 세팅
            result = "0";
        }

        // 연산자(=) 클릭
        public void OnClickResult(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string var2 = result.ToString();

            SetExpress.AddValue(var2);
            Expression = SetExpress.Expression();
            Result = basicOperation.Result(ref SetExpress.expNum, ref SetExpress.expOp);

            // History에 식 추가
            HistoryVM.ExpHistory.Add(Expression + "\n" + Result);

            SetExpress.SetClear();
        }

        // 지우기 버튼 클릭
        public void OnClickClear(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string clear = btn.Content.ToString();
            string var = result.ToString();

            if (expression != "" && !(expression.Substring(expression.Length - 1) == "="))
            {
                SetExpress.SetClear();
            }

            Result = Clear.ResultClear(clear, var, expression);
            Expression = Clear.ExpressionClear(clear, expression);
        }

        // 특수연산 
        public void OnClickSpecial(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string special = btn.Content.ToString();
            string insertNum = result;

            SetExpress.SaveValue(result, special);
            Result = specialOperation.SpecialResult(ref SetExpress.expNum, ref SetExpress.expOp);
            Expression = SetExpress.Expression();
            SetExpress.SetClear();
        }

        // ± 클릭시
        public void OnClickSpecial2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string insertNum = result;

            Result = specialOperation.ChangeSign(insertNum);
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
