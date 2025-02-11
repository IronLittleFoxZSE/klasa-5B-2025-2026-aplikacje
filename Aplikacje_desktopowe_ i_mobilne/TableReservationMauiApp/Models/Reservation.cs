using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservationMauiApp.Models
{
    public class Reservation : BindableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private TimeSpan fromTime;
        public TimeSpan FromTime
        {
            get { return fromTime; }
            set { fromTime = value; OnPropertyChanged(); }
        }

        private TimeSpan toTime;
        public TimeSpan ToTime
        {
            get { return toTime; }
            set { toTime = value; OnPropertyChanged(); }
        }

    }
}
