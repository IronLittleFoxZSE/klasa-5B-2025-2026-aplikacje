using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSimpleCalculatorMauiApp
{
    public class CalculatorViewModel : BindableObject
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public bool IsOperationAdd { get; set; }
        public bool IsOperationSub { get; set; }
        public bool IsOperationMul { get; set; }
        public bool IsOperationDiv { get; set; }

        private string returnMessage;
        public string ReturnMessage
        {
            get { return returnMessage; }
            set { returnMessage = value; OnPropertyChanged(); }
        }

        private Color returnMessageColor;
        public Color ReturnMessageColor
        {
            get { return returnMessageColor; }
            set { returnMessageColor = value; OnPropertyChanged(); }
        }

        private Command calaculateCommand;
        public Command CalaculateCommand
        {
            get { return calaculateCommand; }
            set { calaculateCommand = value; }
        }

        public CalculatorViewModel()
        {
            CalaculateCommand = new Command(Calculate);
        }

        private void Calculate()
        {
            if (!int.TryParse(FirstNumber, out int firstNumber))
            {
                //komunikat o błędzie
                ReturnMessage = "Niepoprawna pierwsza liczba";
                ReturnMessageColor = new Color(255, 0, 0);
                return;
            }

            if (!int.TryParse(SecondNumber, out int secondNumber))
            {
                //komunikat o błędzie
                ReturnMessage = "Niepoprawna druga liczba";
                ReturnMessageColor = new Color(255, 0, 0);
                return;
            }

            int result = 0;
            if (IsOperationAdd)
            {
                result = firstNumber + secondNumber;
            }
            if (IsOperationSub)
            {
                result = firstNumber - secondNumber;
            }
            if (IsOperationMul)
            {
                result = firstNumber * secondNumber;
            }
            if (IsOperationDiv)
            {
                result = firstNumber / secondNumber;
            }

            ReturnMessage = $"Wynik operacji {result}";
            ReturnMessageColor = Colors.Green;
        }
    }
}
