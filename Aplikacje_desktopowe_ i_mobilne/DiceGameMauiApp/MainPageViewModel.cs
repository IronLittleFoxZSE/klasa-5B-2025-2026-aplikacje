using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameMauiApp
{
    public class MainPageViewModel : BindableObject
    {
        private ObservableCollection<int> dieceVaules;
        public ObservableCollection<int> DieceValues
        {
            get { return dieceVaules; }
            set { dieceVaules = value; OnPropertyChanged(); }
        }

        private int gameValue;
        public int GameValue
        {
            get { return gameValue; }
            set { gameValue = value; OnPropertyChanged(); }
        }

        private int totalGameValue;
        public int TotalGameValue
        {
            get { return totalGameValue; }
            set { totalGameValue = value; OnPropertyChanged(); }
        }

        private Command resetCommand;
        public Command ResetCommand
        {
            get
            {
                if (resetCommand == null)
                    resetCommand = new Command(
                        () =>
                        {
                            DieceValues = new ObservableCollection<int>(Enumerable.Repeat(0, 5));
                            GameValue = 0;
                            TotalGameValue = 0;
                        });
                return resetCommand;
            }
        }

        private Command rollDieceCommand;
        public Command RollDieceCommand
        {
            get
            {
                if (rollDieceCommand == null)
                    rollDieceCommand = new Command(
                        () =>
                        {
                            DieceValues = new ObservableCollection<int>();

                            Random random = new Random();
                            for (int i = 0; i < 5; i++)
                                DieceValues.Add(random.Next(1, 7));

                            GameValue = DieceValues.GroupBy(n => n).Where(g => g.Count() > 1).Sum(g => g.Sum());
                            TotalGameValue += GameValue;
                        });
                return rollDieceCommand;
            }
        }

        public MainPageViewModel()
        {
            ResetCommand.Execute(this);
        }
    }
}
