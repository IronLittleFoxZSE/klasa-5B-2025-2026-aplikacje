using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMauiApp.ViewModels
{
    public class CalculatorViewModel : BindableObject
    {
        private int calculationResult;
        public int CalculationResult
        {
            get { return calculationResult; }
            set
            {
                calculationResult = value;
                OnPropertyChanged();

            }
        }

        private Command numericCommand;
        public Command NumericCommand
        {
            get 
            {
                if (numericCommand == null)
                    numericCommand = new Command<string>((strNumber) => 
                    {
                        int digit = int.Parse(strNumber);

                        if (isOperationAction == false)
                        {
                            CalculationResult = CalculationResult * 10 + digit;
                        }
                        else
                        {
                            if (!isOperationEquilAction)
                            {
                                prevValue = CalculationResult;
                            }
                            
                            CalculationResult = digit;
                            isOperationAction = false;
                            isOperationEquilAction = false;
                        }
                    });
                return numericCommand; 
            }
        }

        private Command operationCommand;
        public Command OperationCommand
        {
            get
            {
                if (operationCommand == null)
                    operationCommand = new Command<string>((operationSign) =>
                    {
                        if (isOperationAction)
                            return;
                        CalculationResult = Calculate(prevValue, CalculationResult, prevOperationSign);
                        prevOperationSign = operationSign;
                        isOperationAction = true;
                    });
                return operationCommand;
            }
        }

        private Command operationEquilCommand;
        public Command OperationEquilCommand
        {
            get
            {
                if (operationEquilCommand == null)
                    operationEquilCommand = new Command<string>((operationSign) =>
                    {
                        if (isOperationAction)
                            return;
                        CalculationResult = Calculate(prevValue, CalculationResult, prevOperationSign);
                        prevOperationSign = "*";    //"+"
                        prevValue = 1;              //0
                        isOperationAction = true;
                        isOperationEquilAction = true;
                    });
                return operationEquilCommand;
            }
        }

        private int Calculate(int firstValue , int secondValue, string operationSign)
        {
            int value = 0;

            switch (operationSign)
            {
                case "+":
                    value = firstValue + secondValue;
                    break;
                case "-":
                    value = firstValue - secondValue;
                    break;
                case "*":
                    value = firstValue * secondValue;
                    break;
                case "/":
                    value = firstValue / secondValue;
                    break;
            }

            return value;
        }

        private string prevOperationSign = "*";
        private int prevValue = 1;
        private bool isOperationAction = false;
        private bool isOperationEquilAction = false;

    }
}
