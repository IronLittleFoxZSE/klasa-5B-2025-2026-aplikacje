using System;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //c++
            //typ nazwa = wartość;
            //int liczba = 5;
            //int x,y;

            string imie = "Jan";
            string nazwisko = "Kowalski";
            //nazwisko.Length
            Console.WriteLine("Witaj " + imie + " " + nazwisko + " tutaj");
            Console.WriteLine("Witaj {1} {0} tutaj",imie, nazwisko);
            Console.WriteLine($"Witaj {imie} xxxx {nazwisko} tutaj");


            Console.WriteLine("Prędkość to km\\h");
            Console.WriteLine(@"Prędkość to km\h");

            int liczbaCalkowita = 5;
            double liczbaRzeczywista = 5.6;

            Person firstPerson = new Person();

            firstPerson.ShowInfo();

            //Person *person = new Person();
            //person->ShowInfo();
            //(*person).ShowInfo();

            Person seconPerson = firstPerson;
            seconPerson.ShowInfo();

            Person thirdPerson = new Person("Ala", "Kowalska", 18);
            thirdPerson.ShowInfo();

            seconPerson = thirdPerson;
            seconPerson.ShowInfo();

            thirdPerson.SetSurname("");
            thirdPerson.ShowInfo();

            thirdPerson.SetSurname("Nowakowska");
            thirdPerson.Surname = "Nowakowska";

            thirdPerson.ShowInfo();

            string dana = thirdPerson.GetSurname();
            dana = thirdPerson.Surname;

            //thirdPerson.Age = 50;
            int d = thirdPerson.Age;
            //thirdPerson.Name = "Adam";
            string e = thirdPerson.Name;

        }
    }
}
