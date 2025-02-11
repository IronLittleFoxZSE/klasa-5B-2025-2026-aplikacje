using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateConrtollersMauiApp.ViewModel
{
    public class Field
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class MainViewModel : BindableObject
    {
        public ObservableCollection<string> Names { get; set; }

        public ObservableCollection<Field> Fields { get; set; }

        public MainViewModel()
        {
            Names = new ObservableCollection<string>()
            {
                "Pierwszy", "Drugi", "Trzeci"
            };

            Fields = new ObservableCollection<Field>()
            {
                new Field(){Name = "Ala", X = 2, Y = 3},
                new Field(){Name = "Ola", X = 1, Y = 1},
            };
        }
    }
}
