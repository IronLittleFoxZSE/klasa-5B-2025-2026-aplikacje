using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingParametersToMethod
{
    struct PersonStruct
    {
        public string name;
        public string surname;
        public int age;
    }


    class TestingParamteters
    {
        #region Przekazywanie typów prostych

        public void Test1()
        {
            byte number = 15;
            Console.WriteLine("Zmienna number = " + number);
            ChangeValue(number);
            //ChangeValue(6);
            //ChangeValueV2(ref number);
            //ChangeValueV2(ref 6); //BŁAD!!!!!!!!!
            Console.WriteLine("Zmienna number = " + number);

            int random;//= GetRandomNumber();
            GetRandomNumber(out random);
        }

        private void ChangeValue(byte value)
        {
            Console.WriteLine("Parametr value = " + value);
            value = (byte)(value + 10);
            Console.WriteLine("Parametr value = " + value);
        }

        private void ChangeValueV2(ref byte value)
        {
            Console.WriteLine("Parametr value = " + value);
            value = (byte)(value + 10);
            Console.WriteLine("Parametr value = " + value);
        }

        private int GetRandomNumber()
        {
            return new Random().Next();
        }

        private void GetRandomNumber(out int value)
        {
            //Console.WriteLine("Parametr value = " + value);
            value = new Random().Next();
            Console.WriteLine("Parametr value = " + value);
        }

        #endregion

        #region Przekazywanie typów referencyjnych

        public void Test2()
        {
            Person person = new Person();
            person.ShowInfo();

            //GetPerson(person);
            //GetPerson2(person);
            GetPerson3(ref person);

            person.ShowInfo();
        }

        private void GetPerson(Person p)
        {
            p.ShowInfo();
            p.Age = 40;
            p.ShowInfo();
        }

        private void GetPerson2(Person p)
        {
            p = new Person();
            p.ShowInfo();
            p.Age = 40;
            p.ShowInfo();
        }

        private void GetPerson3(ref Person p)
        {
            p = new Person();
            p.ShowInfo();
            p.Age = 40;
            p.ShowInfo();
        }

        #endregion

        #region Przekazywanie struktur

        public void Test3()
        {
            PersonStruct ps = new PersonStruct();
            ps.name = "Adam";
            Console.WriteLine("Pole name w Test3 " + ps.name);
            GetPresonStruct(ps);
            Console.WriteLine("Pole name w Test3 " + ps.name);
        }

        private void GetPresonStruct(PersonStruct ps)
        {
            Console.WriteLine("Pole name w GetPresonStruct " + ps.name);
            ps.name = "Ewa";
            Console.WriteLine("Pole name w GetPresonStruct " + ps.name);
        }


        #endregion
    }
}
