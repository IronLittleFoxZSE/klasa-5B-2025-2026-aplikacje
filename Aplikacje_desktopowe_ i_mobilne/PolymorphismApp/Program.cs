using System;

namespace PolymorphismApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog firstDog = new Dog();
            Dog secondDog = new Dog("Burek", 5);

            Dog thirdDog = new Dog(secondDog);

            firstDog.ShowInfo();
            secondDog.Bark();
            thirdDog.ChasePostman();

            Cat firstCat = new Cat("Mruczek", 12);
            firstCat.ShowInfo();
            firstCat.Meow();
            firstCat.ClimbOnTree();

            ShowInfoForDog(firstDog);
            ShowInfoForCat(firstCat);

            Animal animal;
            if (new Random().Next() % 2 == 0)
                animal = firstDog;
            else
                animal = firstCat;
            animal.ShowInfo();

            ShowInfoForAnimal(firstCat);
            ShowInfoForAnimal(firstDog);
        }

        static void ShowInfoForDog(Dog dog)
        {
            dog.ShowInfo();
        }

        static void ShowInfoForCat(Cat cat)
        {
            cat.ShowInfo();
        }

        static void ShowInfoForAnimal(Animal animal)
        {
            animal.ShowInfo();
        }
    }
}
/*
class Player
{
    public virtual void Ruch() { }
}

class Człowiek: Player
{
    public override void Ruch() { }
}

class Komputer : Player
{
    public override void Ruch() { }
}

Player[] tab = new Palyer[2];
tab[0] = new Komputer();
tab[1] = new Człowiek();

while (true)
{
    tab[0].Ruch();
    tab[1].Ruch();
}
*/