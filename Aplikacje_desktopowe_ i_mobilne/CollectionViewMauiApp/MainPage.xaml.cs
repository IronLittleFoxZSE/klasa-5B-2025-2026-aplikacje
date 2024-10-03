using System.Collections.ObjectModel;

namespace CollectionViewMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Car> CarsCollection { get; set; }

        public MainPage()
        {
            CarsCollection = new ObservableCollection<Car>()
            {
                new Car()
                {
                    Name = "Opel",
                    Description="O jak Opel"
                },
                new Car()
                {
                    Name = "BMW",
                    Description = "Mam kierunkowskazy!!!!"
                }
            };

            InitializeComponent();
        }
    }

}
