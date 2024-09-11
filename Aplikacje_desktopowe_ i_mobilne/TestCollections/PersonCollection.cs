using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollections
{
    class PersonCollection
    {
        public void Test()
        {
            List<Person> listOfPeople = new List<Person>();
            listOfPeople.Add(new Person()
            {
                Name = "Adam",
                Surname = "Nowak",
                Age = 35,
                Height = 190
            });

            listOfPeople.Add(new Person()
            {
                Name = "Ewa",
                Surname = "Kowalska",
                Age = 25,
                Height = 165
            });

            listOfPeople.Add(new Person()
            {
                Name = "Karol",
                Surname = "Krawczyk",
                Age = 15,
                Height = 172
            });

            listOfPeople.Add(new Person()
            {
                Name = "Adam",
                Surname = "Małysz",
                Age = 15,
                Height = 165
            });

            Console.WriteLine("Wszystkie dane w kolekcji:");
            foreach (Person person in listOfPeople)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            bool isAnyHere = listOfPeople.Any();
            Console.WriteLine("Czy ktoś jest na liście: " + isAnyHere);

            bool isAnyHereUnder18 = listOfPeople.Any(p => p.Age < 18);
            Console.WriteLine("Czy na liście jest osoba niepełnoletnia: " + isAnyHereUnder18);
            Console.WriteLine();

            Person firstOnList = listOfPeople.FirstOrDefault();
            Console.WriteLine("Pierwsza osoba na liście: " + firstOnList);
            Console.WriteLine();

            Person firstPersonWidthHeightOdd = listOfPeople.FirstOrDefault(p => p.Height % 2 == 1);
            Console.WriteLine("Pierwsza osoba na liście z nieparzystym wzrostem: " + firstPersonWidthHeightOdd);
            Console.WriteLine();

            List<Person> peopleSortHeight = listOfPeople.OrderBy(p => p.Height).ToList();
            Console.WriteLine("Posortowana lista wedłóg wzrostu");
            foreach (Person person in peopleSortHeight)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            List<Person> peopleSortHeightAndAge = listOfPeople
                .OrderBy(p => p.Height)
                .ThenByDescending(p => p.Age)
                .ToList();
            Console.WriteLine("Posortowana lista według wzrostu i wieku");
            foreach (Person person in peopleSortHeightAndAge)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            var x = listOfPeople.Where(p => p.Age >= 18).OrderBy(p => p.Height).FirstOrDefault();

        }

        private bool OwnAny(List<Person> list, Func<Person, bool> check)
        {
            foreach (Person person in list)
            {
                if (check(person))
                    return true;
            }
            return false;
        }

    }
}
