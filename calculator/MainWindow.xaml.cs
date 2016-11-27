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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorModel calc = new CalculatorModel();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("1");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("2");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("3");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("4");
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("5");
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("6");
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("7");
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("8");
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("9");
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText("0");
        }
        private void deledeLastSymbol(object sender, RoutedEventArgs e)
        {
            string s = textBoxInput.Text;
            if (!string.IsNullOrEmpty(textBoxInput.Text))
                textBoxInput.Text = s.Substring(0, s.Length - 1);
        }
        private void clearAll(object sender, RoutedEventArgs e)
        {
            calc.Clear();
            textBoxInput.Clear();
            textBoxOutput.Clear();
        }

        private void signChange_Click(object sender, RoutedEventArgs e)
        {
            string value = textBoxInput.Text;
            double result;
            if (!string.IsNullOrEmpty(value) && Double.TryParse(value, out result))
            {
                try
                {
                    Double.Parse(value);
                }
                catch (OverflowException)
                {
                    textBoxInput.Text = "Input value is outside the range of the Double type.";
                }
                catch (FormatException)
                {
                    textBoxInput.Text = "Input value is wrong.";
                }
                catch (ArgumentNullException)
                {
                    textBoxInput.Text = "Input value is null.";
                }
                result = Double.Parse(value) * -1;
                textBoxInput.Text = result.ToString();
            }
            else MessageBox.Show("Wrong input!!!");
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            operationbutton("+");
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            operationbutton("-");
        }

        private void mutlipty_Click(object sender, RoutedEventArgs e)
        {
            operationbutton("*");
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            operationbutton("/");
        }

        private void floatPoint(object sender, RoutedEventArgs e)
        {
            textBoxInput.AppendText(".");
        }

        private void operationbutton(string op)
        {
            if (string.IsNullOrEmpty(calc.Result))
            {
                calc.FirstOperand = textBoxInput.Text;
                calc.Operation = op;
                textBoxOutput.Text = calc.FirstOperand + calc.Operation;
                textBoxInput.Clear();
            }
            else
            {
                calc.FirstOperand = calc.Result;
                calc.Operation = op;
                textBoxOutput.Text = calc.FirstOperand + calc.Operation;
                textBoxInput.Clear();
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            calc.SecondOperand = textBoxInput.Text;
            if (!string.IsNullOrEmpty(calc.FirstOperand)&& !string.IsNullOrEmpty(calc.SecondOperand) && !string.IsNullOrEmpty(calc.Operation))
            {
                calc.CalculateResult();
                textBoxOutput.Text = calc.FirstOperand + calc.Operation + calc.SecondOperand + "=" + calc.Result;
                textBoxInput.Clear();
            }
        }
    }
}