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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double number1 = 0;
        static double number2 = 0;
        string op = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String number = button.Content.ToString();
            if (txtValue.Text == "0")
            {
                txtValue.Text = number;
            }
            else
            {
                txtValue.Text += number;
            }
            if(op == "")
            { 
            number1 = Double.Parse(txtValue.Text);
            
            }
            else
            {
                number2 = Double.Parse(txtValue.Text);
            }
        }

       
       

        private void btn_op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            txtValue.Text = "0";
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (op)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
                case "avg":
                    result = (number1 + number2)/2;
                    break;
                case "max":
                    result = Math.Max(number1, number2);
                    break;
                case "min":
                    result = Math.Min(number1, number2);
                    break;
                case "x^y":
                    result = Pow(number1, (int)number2);
                    break;
            }
            txtValue.Text = result.ToString();
            op = "";
            number1 = result;
            number2 = 0;
        }

        //private double Pow(double number1, double number2)
        //{
        //    int result = 1;
        //    for (int i = 1; i <= y; i++)
        //    {
        //        result *= x;
        //    }
        //    return result;
        //}
        private double Pow(double number1, int number2)
        {
        if(number2 == 0)
                return 1;
        
        return Pow(number1, number2 - 1) * number1;

        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            op = "";
            txtValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if(op == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }
            txtValue.Text = "0";
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Text = DropLastChar(txtValue.Text);
            if(op == "")
            {
                number1 = Double.Parse(txtValue.Text);
               
            }
            else
            {
                number2 = Double.Parse(txtValue.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if(text.Length == 1)
            {
                text = "0";
            }
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if(op == "")
            {
                number1 *= -1;
                txtValue.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                txtValue.Text = number2.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                SetComma(number1);
            else
                SetComma(number2);
        }

        private void SetComma(double number)
        {

            if (txtValue.Text.Contains(',')) { return; }
             txtValue.Text += ',';
        }
    }
}
