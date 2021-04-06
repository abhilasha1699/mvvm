using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace mvvm.ViewModels
{
    class CalculatorViewModel : BaseViewModel
    {
        private double firstNumber, secondNumber;
        private string displayValue;
        private int current = 1;
        private string operation;

        public CalculatorViewModel()
        {
            DigitCommand = new Command<string>(DigitCommandExecute);
            OperatorCommand = new Command<string>(OperatorCommandExecute);
            DeleteCommand = new Command(DeleteCommandExecute);
            ClearCommand = new Command(ClearCommandExecute);
            EvaluateCommand = new Command(EvalauteCommandExecute);

            ///DisplayValue = string.Empty;
        }

        public string DisplayValue
        {
            get { return displayValue; }
            set
            {
                displayValue = value;
                OnPropertyChanged("DisplayValue");
            }
        }

        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber = value;
                OnPropertyChanged("FirstNumber");
            }
        }

        public double SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                OnPropertyChanged("SecondNumber");
            }
        }

        public string Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                OnPropertyChanged("Operation");
            }
        }

        public ICommand DigitCommand { get; private set; }
        public ICommand OperatorCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand EvaluateCommand { get; private set; }

        private void EvalauteCommandExecute(object obj)
        {
            if (current == 2)
            {
                var resultOperation = (Operator.Calculate(FirstNumber, SecondNumber, Operation)).ToString();
                string newDisplay = resultOperation.ToString();
                DisplayValue = newDisplay;
                current = -1;
            }
        }

        private void ClearCommandExecute(object obj)
        {
            firstNumber = 0;
            secondNumber = 0;
            DisplayValue = "0";
            current = 1;
        }

        private void DeleteCommandExecute(object obj)
        {
            if (DisplayValue != string.Empty)
            {
                int txtLength = DisplayValue.Length;
                if (txtLength != 1)
                {
                    DisplayValue = DisplayValue.Remove(txtLength - 1);
                }
                else
                {
                    DisplayValue = 0.ToString();
                }
            }
        }

        private void OperatorCommandExecute(string value)
        {
            current = -2;
            //string newDisplay = DisplayValue + value;
            DisplayValue += value;
            operation = value;
        }

        private void DigitCommandExecute(string value)
        {
            if(displayValue=="0" || current < 0)
            {
                displayValue = " ";
                if (current < 0)
                {
                    current *= -1;
                }
            }

            //string newDisplay = DisplayValue + value;
            DisplayValue += value;
            string newDisplay = DisplayValue;
            double num;
            if(Double.TryParse(newDisplay, out num))
            {
                if (current == 1)
                {
                    firstNumber = num;
                }
                else
                {
                    secondNumber = num;
                }
            }

            DisplayValue = newDisplay;
        }
    }
}
