namespace DindingSimpleCalculatorMauiApp
{
    public partial class MainPage : ContentPage
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


        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(FirstNumber, out int firstNumber))
            {
                //komunikat o błędzie
                ReturnMessage = "Niepoprawna pierwsza liczba";
                ReturnMessageColor = new Color(255, 0, 0);
                return;
            }
            ttt.
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
