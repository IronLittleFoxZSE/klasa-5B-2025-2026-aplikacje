using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCodeFirstDatabaseClassLibrary.Models
{
    internal class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MaxLength(60)]
        [Required]
        public string Surname { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        public string Country { get; set; }

        public int MainAddressId { get; set; }

        public Address MainAddress { get; set; }

        public int SecondAddressId { get; set; }
        public Address SecondAddress { get; set; }
    }
}

/*
 select * 
from People p
join Addresses a on a.Id = p.SecondAddressId

peopleDbContext.People.Include(p => p.SecondAddress);
*/
