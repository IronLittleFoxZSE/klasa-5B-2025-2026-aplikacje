using PeopleDatabaseClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDatabaseMauiApp
{
    public class MainPageViewModel : BindableObject
    {
        private PeopleRepository peopleRepository = new PeopleRepository();

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }

        public Command createPersonCommand;
        public Command CreatePersonCommand
        {
            get
            {
                if (createPersonCommand == null)
                    createPersonCommand = new Command(() =>
                    {
                        peopleRepository.CreateNewPerson(name, surname, age);
                    });

                return createPersonCommand;
            }
        }
    }
}
