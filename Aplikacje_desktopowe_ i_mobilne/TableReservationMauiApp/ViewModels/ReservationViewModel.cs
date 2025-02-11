using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReservationMauiApp.Models;

namespace TableReservationMauiApp.ViewModels
{
    class ReservationViewModel : BindableObject
    {
        private int columnCount;
        public int ColumnCount
        {
            get { return columnCount; }
            set
            {
                columnCount = value;
                OnPropertyChanged();
            }
        }

        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
            set
            {
                rowCount = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Table> Tables { get; set; }

        private Command tableCommand;
        public Command TableCommand
        {
            get
            {
                if (tableCommand == null)
                    tableCommand = new Command<Table>(
                        t =>
                        {
                            if (CurrentSelectedTable != null)
                                CurrentSelectedTable.ColorTable = Colors.LightGreen;


                            ShowReservation = true;
                            CurrentSelectedTable = t;
                            CurrentSelectedTable.ColorTable = Colors.Green;
                            SelectedReservation = CurrentSelectedTable.TableReservations.FirstOrDefault();
                        }

                        );
                return tableCommand;
            }
        }

        private Command newReservationCommand;
        public Command NewReservationCommand
        {
            get
            {
                if (newReservationCommand == null)
                    newReservationCommand = new Command<Table>(
                        t =>
                        {
                            Reservation newReservation = new Reservation();

                            t.TableReservations.Add( newReservation );
                            SelectedReservation = newReservation;
                        }

                        );
                return newReservationCommand;
            }
        }

        private Table currentSelectedTable;

        public Table CurrentSelectedTable
        {
            get { return currentSelectedTable; }
            set { currentSelectedTable = value; OnPropertyChanged(); }
        }

        private bool showReservation;

        public bool ShowReservation
        {
            get { return showReservation; }
            set { showReservation = value; OnPropertyChanged(); }
        }

        private Reservation selectedReservation;

        public Reservation SelectedReservation
        {
            get { return selectedReservation; }
            set { selectedReservation = value; OnPropertyChanged(); }
        }



        public ReservationViewModel()
        {
            ColumnCount = 20;
            RowCount = 20;

            Tables = new ObservableCollection<Table>()
            {
                new Table(){X=1,Y=1, ColorTable = Colors.LightGreen, TableCommand = TableCommand},
                new Table(){X=2,Y=2, ColorTable = Colors.LightGreen, TableCommand = TableCommand},
                new Table(){X=3,Y=3, ColorTable = Colors.LightGreen, TableCommand = TableCommand},
            };

            Tables[0].TableReservations.Add(new Reservation() { Name = "Jan", FromTime=new TimeSpan(1,0,0), ToTime=new TimeSpan(10,0,0) });
            Tables[0].TableReservations.Add(new Reservation() { Name = "Karol", FromTime = new TimeSpan(1, 0, 0), ToTime = new TimeSpan(10, 0, 0) });
            Tables[1].TableReservations.Add(new Reservation() { Name = "Ewa", FromTime = new TimeSpan(1, 0, 0), ToTime = new TimeSpan(10, 0, 0) });

            currentSelectedTable = null;
        }

    }
}
