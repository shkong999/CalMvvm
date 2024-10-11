using CalMvvm.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalMvvm.ViewModel
{
    public class HistoryViewModel
    {
        public ObservableCollection<string> ExpHistory { get; set; } = new ObservableCollection<string>();

        public void History_Clear(object sender, RoutedEventArgs e) => ExpHistory.Clear();
    }
}
