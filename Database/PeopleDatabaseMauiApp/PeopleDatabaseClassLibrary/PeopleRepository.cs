using PeopleDatabaseClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDatabaseClassLibrary
{
    public class PeopleRepository
    {
        private PeopleDBContext dbContext;

        public PeopleRepository()
        {
            dbContext = new PeopleDBContext();
        }

        public void CreateNewPerson(string name, string surname, int age)
        {
            Person person = new()
            {
                Name = name,
                Surname = surname,
                Age = age
            };

            dbContext.People.Add(person);
            dbContext.SaveChanges();
        }

        public List<Person> GetLegalAgePeople()
        {
            /*
                select Age
                from People p
                where Age >= 18
                order by Name asc, Surname desc
            */
            return dbContext
                .People
                .Where(p => p.Age >= 18)
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Surname)
                //.Select(p => p)
                .ToList();
        }

        public void SaveChangePerson(Person currentPersonSelection)
        {
            Person personToUpdate = dbContext.People.FirstOrDefault(p=> p.Id == currentPersonSelection.Id);
            if (personToUpdate != null)
            {
                personToUpdate.Name= currentPersonSelection.Name;
                personToUpdate.Surname= currentPersonSelection.Surname;
                personToUpdate.Age= currentPersonSelection.Age;
                dbContext.SaveChanges();
            }
        }
    }
}
