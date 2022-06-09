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

namespace Num_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num = 0, result = 0;
        string tempStr = "";
        bool flag = true;
        char operation=' ';

        public MainWindow()
        {
            InitializeComponent();
            input.Text = "0";

            btn_0.Click += Count_Click;
            btn_1.Click += Count_Click;
            btn_2.Click += Count_Click;
            btn_3.Click += Count_Click;
            btn_4.Click += Count_Click;
            btn_5.Click += Count_Click;
            btn_6.Click += Count_Click;
            btn_7.Click += Count_Click;
            btn_8.Click += Count_Click;
            btn_9.Click += Count_Click;

            Point_button.Click += Point_Click;
            CE_button.Click += CE_Click;
            C_button.Click += C_Click;

            Plus_button.Click += Operation_Click;
            Minus_button.Click += Operation_Click;
            Div_button.Click += Operation_Click;
            Mult_button.Click += Operation_Click;
            Equally_button.Click += Equally_Click;
            Min_button.Click += Min_Click;
        }
        private void Min_Click(object sender,RoutedEventArgs e)
        {
            if(input.Text.Length!=0)
            {
                //input.Text= input.Text.Remove(input.Text.Length - 1, 1);
                //tempStr= tempStr.Remove(input.Text.Length - 1, 1);

                if (input.Text == "0")
                    return;
                if (input.Text.Length == 1)
                    return;

                input.Text = input.Text.Substring(0,input.Text.Length - 1);
                tempStr = tempStr.Substring(0,tempStr.Length - 1);
            }
            
        }
        private void Equally_Click(object sender,RoutedEventArgs e)
        {
            if (previous.Text.EndsWith("/") && input.Text == "0")
            {
                input.FontSize = 20;
                input.Text = "Невозможно делить на 0";
                Div_button.IsEnabled = false;
                Mult_button.IsEnabled = false;
                Plus_button.IsEnabled = false;
                Minus_button.IsEnabled = false;
                Point_button.IsEnabled = false;
            }
            else
            {
                if(input.Text == "Невозможно делить на 0")
                {
                    input.FontSize = 35;
                    operation = ' ';
                    previous.Text = "";
                    input.Text = "0";
                    Div_button.IsEnabled = true;
                    Mult_button.IsEnabled = true;
                    Plus_button.IsEnabled = true;
                    Minus_button.IsEnabled = true;
                    Point_button.IsEnabled = true;
                    return;
                }
                tempStr += "=";
                previous.Text = tempStr;
                num = Double.Parse(input.Text);
                Calculator(num, operation);
                input.Text = result.ToString();

                tempStr = "";
                num = 0;
                result = 0;
            }
            flag = false;
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (previous.Text.EndsWith("/") && input.Text == "0")
            {
                input.FontSize = 20;
                input.Text = "Невозможно делить на 0";
                Div_button.IsEnabled = false;
                Mult_button.IsEnabled = false;
                Plus_button.IsEnabled = false;
                Minus_button.IsEnabled = false;
                Point_button.IsEnabled = false;
            }
            else
            {
                if (input.Text == "0")
                    tempStr = "0";
                
                Button b = sender as Button;

                if (tempStr.EndsWith("*") || tempStr.EndsWith("/") || tempStr.EndsWith("+") || tempStr.EndsWith("-"))
                {
                    tempStr = tempStr.Remove(tempStr.Length - 1, 1) + b.Content.ToString();
                    previous.Text = tempStr;
                    operation = Char.Parse(b.Content.ToString());
                    return;
                }

                tempStr += b.Content.ToString();
                previous.Text = tempStr;

                if (result == 0)
                    result = Double.Parse(input.Text);
                else if (num == 0)
                {
                    num = Double.Parse(input.Text);
                    Calculator(num, operation);
                    input.Text = result.ToString();
                    previous.Text = result.ToString() + b.Content.ToString();
                }
            operation=Char.Parse(b.Content.ToString());
            }
            flag = false;
        }
        private void C_Click(object sender, RoutedEventArgs e)
        {
            previous.Text = "";
            tempStr = input.Text = "0";
            result = 0;
        }
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (previous.Text.Length != 0)
                input.Text = "0";
            else
                tempStr = input.Text = "0";
        }
        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (previous.Text.EndsWith("="))
            {
                previous.Text = "";
                input.Text = "0,";
                tempStr = "0,";
                flag = true;
                return;
            }
            if (input.Text == "0" || !(input.Text.Contains(",")))
            {
                input.Text += ",";
                tempStr += ",";
            }
        }
        private void Count_Click(object sender, RoutedEventArgs e)
        {
            input.FontSize = 35;
            if (input.Text == "Невозможно делить на 0")
            {
                operation = ' ';
                previous.Text = "";
                Div_button.IsEnabled = true;
                Mult_button.IsEnabled = true;
                Plus_button.IsEnabled = true;
                Minus_button.IsEnabled = true;
                Point_button.IsEnabled = true;
            }
            if (!flag)
            {
                input.Text = "0";
                flag = true;
                num = 0;
            }
            if (previous.Text.EndsWith("="))
                previous.Text = "";

            Button b = sender as Button;

            input.Text += b.Content.ToString();
            if (input.Text == $"0{b.Content}" && input.Text != "0,")
            {
                input.Text = b.Content.ToString();
                if (b.Content.ToString() == "0")
                    return;
            }
            tempStr += b.Content.ToString();
        }
        private void Calculator(double a, char c)
        {
            if (a == 0 && result == 0)
                return;
            if (c == '+')
                result += a;
            if (c == '-')
                result -= a;
            if (c == '*')
                result *= a;
            if (c == '/')
            {
                if (a == 0)
                    result = 0;
                else result /= 2;
            }
        }
    }
}
