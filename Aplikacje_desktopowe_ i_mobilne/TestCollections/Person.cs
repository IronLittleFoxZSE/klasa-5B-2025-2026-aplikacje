using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollections
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            string result = "";
            result += Name + " " + Surname;
            result += " Wiek:" + Age;
            result += " Wzrost: " + Height;
            return result;
        }
    }
}
