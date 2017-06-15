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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string numStr;
        private double firstOperand;
        private double secondOperand;
        private string currOperator;
        private bool finishedAround;

        public MainWindow()
        {
            InitializeComponent();
            numStr = "0";
            finishedAround = true;
        }

        //when numbers are clicked
        private void Click_Num(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            //Just boot up or just finished around of calculation
            if (finishedAround){
                numStr = btn.Content.ToString();
                finishedAround = false;
            }
            else if (numStr.Length >= 14) return;
            else numStr += btn.Content.ToString();
            Display.Text = numStr;
        }

        //when operator are clicked
        private void Click_Operator(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            firstOperand = Convert.ToDouble(numStr);
            currOperator = btn.Content.ToString();
            numStr = "";
            Display.Text = currOperator;
        }

        //when equal sign is clicked
        private void Click_Calculate(object sender, RoutedEventArgs e)
        {
            secondOperand = Convert.ToDouble(numStr);
            if (currOperator == "+")
            {
                firstOperand += secondOperand;
            }
            else if (currOperator == "-")
            {
                firstOperand -= secondOperand;
            }
            else if (currOperator == "/")
            {
                firstOperand = firstOperand / secondOperand;
            }
            else if (currOperator == "X") {
                firstOperand = firstOperand * secondOperand;
            }
            //reset operator
            currOperator = ""; 
            numStr = firstOperand.ToString();
            Display.Text = numStr;
            finishedAround = true;
        }

        //clear everything
        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            numStr = "0";
            firstOperand = 0.0;
            secondOperand = 0.0;
            currOperator = "";
            Display.Text = numStr;
            finishedAround = true;
        }
    }
}
