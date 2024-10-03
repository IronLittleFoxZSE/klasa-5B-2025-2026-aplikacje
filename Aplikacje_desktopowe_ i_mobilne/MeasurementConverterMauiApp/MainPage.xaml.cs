using System.Collections.ObjectModel;

namespace MeasurementConverterMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Measure> MeasuresCollection { get; set; }
        public Measure SelectedMeasuresFrom { get; set; }
        public Measure SelectedMeasuresTo { get; set; }

        public string StrValue { get; set; }

        private string resultConverter;

        public string ResultConverter
        {
            get { return resultConverter; }
            set { resultConverter = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            MeasuresCollection = new ObservableCollection<Measure>()
            {
                new Measure()
                {
                    Name = "milimetry",
                    Converter = 1,
                    Symbol = "mm"
                },
                new Measure()
                {
                    Name = "centymetry",
                    Converter = 10,
                    Symbol = "cm"
                },
                new Measure()
                {
                    Name = "metry",
                    Converter = 1000,
                    Symbol = "m"
                },
                new Measure()
                {
                    Name = "kilometry",
                    Converter = 1000000,
                    Symbol = "km"
                }
            };
            SelectedMeasuresFrom = MeasuresCollection.First();
            SelectedMeasuresTo = MeasuresCollection.First();

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(StrValue, out double value))
            {
                ResultConverter = "Nieprawidłowa dana";
            }

            double result = value * SelectedMeasuresFrom.Converter / SelectedMeasuresTo.Converter;

            ResultConverter = $"Wartość {value} {SelectedMeasuresFrom.Symbol} = {result} {SelectedMeasuresTo.Symbol}";
        }
    }

}
