using PeopleDatabaseClassLibrary;
using PeopleDatabaseClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Person> People { get; set; }

        public Command getLegalAgePeopleCommand;
        public Command GetLegalAgePeopleCommand
        {
            get
            {
                if (getLegalAgePeopleCommand == null)
                    getLegalAgePeopleCommand = new Command(() =>
                    {
                        List<Person> legalAgePeople = peopleRepository.GetLegalAgePeople();
                        People.Clear();
                        foreach (Person person in legalAgePeople)
                        {
                            People.Add(person);
                        }
                    });

                return getLegalAgePeopleCommand;
            }
        }

        private Person currentPersonSelection;

        public Person CurrentPersonSelection
        {
            get { return currentPersonSelection; }
            set { currentPersonSelection = value; OnPropertyChanged(); }
        }

        public Command saveChangesCommand;
        public Command SaveChangesCommand
        {
            get
            {
                if (saveChangesCommand == null)
                    saveChangesCommand = new Command(() =>
                    {
                        if (currentPersonSelection != null)
                            peopleRepository.SaveChangePerson(currentPersonSelection);
                    });

                return saveChangesCommand;
            }
        }

        public MainPageViewModel()
        {
            People = new ObservableCollection<Person>();
        }
    }
}
