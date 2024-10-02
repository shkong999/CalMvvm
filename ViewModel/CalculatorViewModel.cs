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

        private string var = "";
        public string Var
        {
            get
            {
                // 초기 상태일 때 0으로 세팅
                if (var == "")
                {
                    var = "0";
                    return var;
                }
                return var;
            }
            set
            {
                if (value != var)
                {
                    var = value;
                    OnPropertyChanged(nameof(Var));
                }
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            // 입력한 값
            var insertNum = btn.Content.ToString();

            Var = Model.Variable.ChkNum(var, insertNum);
        }
    }
}
