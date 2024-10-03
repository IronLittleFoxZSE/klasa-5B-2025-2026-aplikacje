using System.Collections.ObjectModel;

namespace ShowCollectionMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> FruitsCollection { get; set; }

        public string SelectedFruit { get; set; }

        private string selectedFruitMessage;
        public string SelectedFruitMessage
        {
            get { return selectedFruitMessage; }
            set { selectedFruitMessage = value; OnPropertyChanged(); }
        }

        public string NewFruitName { get; set; }

        public ObservableCollection<Car> CarsCollection { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            FruitsCollection = new ObservableCollection<string>
            {
                "Banan",
                "Mandarynka",
                "Jabłko"
            };

            CarsCollection = new ObservableCollection<Car>() 
            {
                new Car()
                {
                    Name = "Opel",
                    Description = "Samochód dla mnie"
                },
                new Car()
                {
                    Name = "Peugeot",
                    Description = "Nie wszyscy lubią literę F"
                }
            };
            SelectedCar = CarsCollection.First();

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SelectedFruitMessage = "Wybrano owoc: " + SelectedFruit;
        }

        private void Button_Clicked_NewFruit(object sender, EventArgs e)
        {
            FruitsCollection.Add(NewFruitName);
        }
    }
}
