using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollections
{
    class ArrayTest
    {
        public void Test()
        {
            /*
             C++:
            int tab[5];
            tab[2] = 77;
            *(tab + 2) = 77;
            
            */

            int[] tab = new int[5];
            tab[2] = 72;

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = 2;
            }

        }
    }
}
