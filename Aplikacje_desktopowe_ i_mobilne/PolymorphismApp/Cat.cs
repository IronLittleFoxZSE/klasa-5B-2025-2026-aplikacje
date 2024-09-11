using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
DRY - don't repeat yourself
*/


namespace PolymorphismApp
{
    class Cat : Animal
    {
        public Cat()
        {
            name = "Puszek";
            type = "Kot";
        }

        public Cat(string name, byte age) : base(name, age)
        {
            type = "Kot";
        }

        public Cat(Cat catToCopy) : base(catToCopy)
        {
        }

        public void Meow()
        {
            Console.WriteLine("Kot o imieniu " + name + " miauczy");
        }

        public void ClimbOnTree()
        {
            Console.WriteLine("Kot o imieniu " + name + " wchodzi na drzewo");
        }
    }
}
