using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollections
{
    class ListTest
    {
        public void Test()
        {
            List<int> listOfInts = new List<int>();

            Console.WriteLine("Ilość elementów w kolekcji int'ów: " + listOfInts.Count);

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                listOfInts.Add(random.Next(0, 21));
            }

            Console.WriteLine("Lista wylosowanych int'ów");
            for (int i = 0; i < listOfInts.Count; i++)
            {
                Console.Write(listOfInts[i] + ", ");
            }
            Console.WriteLine();

            List<double> listOfDoubles = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                listOfDoubles.Add(Math.Round(random.NextDouble() * 20, 2));
            }

            Console.WriteLine("Lista wylosowanych double'ów");
            foreach (var item in listOfDoubles)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("Max w int'ach: " + MaxFromInts(listOfInts));
            Console.WriteLine("Max w int'ach: " + MaxFromAllTypes<int>(listOfInts, CheckTwoInts));
            Console.WriteLine("Max w int'ach: " + MaxFromAllTypes(listOfInts, (int a, int b) =>
                                                                                    {
                                                                                        return a > b;
                                                                                    } ));
            Console.WriteLine("Max w double'ach: " + MaxFromDoubles(listOfDoubles));
            Console.WriteLine("Max w double'ach: " + MaxFromAllTypes<double>(listOfDoubles, CheckTwoDoubles));
            Console.WriteLine("Max w double'ach: " + MaxFromAllTypes(listOfDoubles, (a, b) => a > b ));


            List<int> newList = CollectionRange<int>(listOfInts, a => a > 5);
            newList = CollectionRange(listOfInts, a => a > 5 && a < 10);

            newList = listOfInts.Where(x => x > 5 && x < 10).ToList<int>();
            var newList2 = listOfDoubles.Where(x => x > 5 && x < 10).ToList();

        }

        private bool CheckTwoInts(int a, int b)
        {
            return a > b;
        }

        private bool CheckTwoDoubles(double a, double b)
        {
            return a > b;
        }

        private int MaxFromInts(List<int> list)
        {
            int max = list[0];
            foreach (int item in list)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }

        private double MaxFromDoubles(List<double> list)
        {
            double max = list[0];
            foreach (double item in list)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }

        //Action
        //Func
        private T MaxFromAllTypes<T>(List<T> list, Func<T, T, bool> check)
        {
            T max = list[0];
            foreach (T item in list)
            {
                if (check(item, max))
                    max = item;
            }
            return max;
        }

        private List<T> CollectionRange<T>(List<T> list, Func<T, bool> check)
        {
            List<T> outList = new List<T>();
            foreach (T item in list)
            {
                if (check(item))
                    outList.Add(item);
            }
            return outList;
        }

    }
}
