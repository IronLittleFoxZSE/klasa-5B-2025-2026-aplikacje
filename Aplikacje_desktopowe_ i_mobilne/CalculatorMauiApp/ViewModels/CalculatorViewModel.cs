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
                        CalculationResult = CalculationResult * 10 + digit;
                    });
                return numericCommand; 
            }
        }
    }
}
