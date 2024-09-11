namespace SimpleCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {           
            if (!int.TryParse(firstNumberEntry.Text, out int firstNumber))
            {
                //komunikat o błędzie
                resultLabel.Text = "Niepoprawna pierwsza liczba";
                resultLabel.TextColor = new Color(255,0,0);
                return;
            }

            if (!int.TryParse(secondNumberEntry.Text, out int secondNumber))
            {
                //komunikat o błędzie
                resultLabel.Text = "Niepoprawna druga liczba";
                resultLabel.TextColor = new Color(255, 0, 0);
                return;
            }

            int result = 0;
            if (operationAddRadioButton.IsChecked)
            {
                result = firstNumber + secondNumber;
            }
            if (operationSubRadioButton.IsChecked)
            {
                result = firstNumber - secondNumber;
            }
            if (operationMulRadioButton.IsChecked)
            {
                result = firstNumber * secondNumber;
            }
            if (operationDivRadioButton.IsChecked)
            {
                result = firstNumber / secondNumber;
            }

            resultLabel.Text = $"Wynik operacji {result}";
            resultLabel.TextColor = Colors.Green;
        }
    }

}
