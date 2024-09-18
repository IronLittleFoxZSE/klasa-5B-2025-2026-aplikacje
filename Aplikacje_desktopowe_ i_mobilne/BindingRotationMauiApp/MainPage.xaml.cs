namespace BindingRotationMauiApp
{
    public partial class MainPage : ContentPage
    {
        public string Message { get; set; }

        private string processedMessage;
        public string ProcessedMessage
        {
            get { return processedMessage; }
            set 
            { 
                processedMessage = value;
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();
        }

        private void levelSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            messageLabel.Text = $"Poziom suwaka {levelSlider.Value}";
            rotateLabel.Rotation = levelSlider.Value;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //ProcessedMessage
            string message = Message;

            int numberOfCharacters = message.Length;

            ProcessedMessage = $"Ilość znaków w komunikacie: {numberOfCharacters}";
        }
    }

}
