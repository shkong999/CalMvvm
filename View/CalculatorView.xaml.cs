﻿using CalMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
           /* CalculatorViewModel calcVM = new CalculatorViewModel();
            DataContext = calcVM;*/

            InitializeComponent();

            DataContext = new CalculatorViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Basic(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {

        }
    }
}