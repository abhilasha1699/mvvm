using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    class Operator
    {
        public static double Calculate(double firstNumber, double secondNumber, string Operator)
        {
            double result = 0;
            switch (Operator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "×":
                    result = firstNumber * secondNumber;
                    break;

                case "÷":
                    result = firstNumber / secondNumber;
                    break;

                case "%":
                    result = firstNumber / 100;
                    break;
            }
            return result;
        }
    }
}
