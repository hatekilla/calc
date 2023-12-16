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

namespace _1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private double? firstNumber = null;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            UpdateDisplay();
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (double.TryParse(currentInput, out double number))
                {
                    if (firstNumber.HasValue)
                    {
                        Calculate();
                        operation = ((Button)sender).Content.ToString();
                        currentInput = "";
                    }
                    else if (operation == "")
                    {
                        firstNumber = number;
                        operation = ((Button)sender).Content.ToString();
                        currentInput = "";
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректное число.");
                }
            }
            else if (((Button)sender).Content.ToString() == "-")
            {
                currentInput = "-";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(currentInput, out double secondNumber))
            {
                if (firstNumber.HasValue)
                {
                    Calculate();
                    currentInput = firstNumber.ToString();
                    firstNumber = null;
                    operation = "";
                }
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
            UpdateDisplay();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            firstNumber = null;
            operation = "";
            UpdateDisplay();
        }

        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    firstNumber += double.Parse(currentInput);
                    break;
                case "-":
                    firstNumber -= double.Parse(currentInput);
                    break;
                case "*":
                    firstNumber *= double.Parse(currentInput);
                    break;
                case "/":
                    double secondNumber = double.Parse(currentInput);
                    if (secondNumber != 0)
                    {
                        firstNumber /= secondNumber;
                    }
                    else
                    {
                        MessageBox.Show("Деление на ноль недопустимо.");
                    }
                    break;
            }
        }
        private void UpdateDisplay()
        {
            textBlock.Text = currentInput;
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                currentInput = "-";
            }
            else if (currentInput == "-")
            {
                currentInput = "";
            }
            else
            {
                currentInput = "-" + currentInput;
            }
            UpdateDisplay();
        }
    }
}
