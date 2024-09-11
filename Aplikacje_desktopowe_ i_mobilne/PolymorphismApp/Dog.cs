using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismApp
{

    class Dog : Animal
    {
        public Dog() //: base() - to jest domyslne
        {
            name = "Azor";
            type = "Pies";
        }

        public Dog(string name, byte age) : base(name, age)
        {
            type = "Pies";
        }

        public Dog(Dog dogToCopy): base(dogToCopy)
        {
        }

        public void Bark()
        {
            Console.WriteLine("Pies o imieniu " + name + " szczeka");
        }

        public void ChasePostman()
        {
            Console.WriteLine("Pies o imieniu " + name + " goni listonosza");
        }

        public override void ShowInfo()
        {
            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine("Przedstawienie psa:");
            Console.WriteLine(type + " o imieniu " + name + " ma " + age + " lat");  
            Console.WriteLine("+++++++++++++++++++++++++");
        }
    }
}
