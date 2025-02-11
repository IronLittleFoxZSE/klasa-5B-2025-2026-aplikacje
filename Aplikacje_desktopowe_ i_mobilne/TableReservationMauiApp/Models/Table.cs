using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservationMauiApp.Models
{
    public class Table : BindableObject
    {
		private int x;
		public int X
		{
			get { return x; }
			set { x = value; OnPropertyChanged(); }
		}

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged(); }
        }

		private Color colorTable;
		public Color ColorTable
		{
			get { return colorTable; }
			set { colorTable = value; OnPropertyChanged(); }
		}

		public ObservableCollection<Reservation> TableReservations { get; set; } = new ObservableCollection<Reservation>();

        private Command tableCommand;

		public Command TableCommand
        {
			get { return tableCommand; }
			set { tableCommand = value; }
		}

	}
}
