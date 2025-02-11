using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetNext<T>(this IList<T> collection, T currentItem)
        {
            if (collection == null || collection.Count == 0) 
                throw new ArgumentException("Collection cannot be null or empty.");
            int currentIndex = collection.IndexOf(currentItem);
            if (currentIndex == -1 || currentIndex == collection.Count - 1) 
                return collection[0];
            return collection[currentIndex + 1];
        }

        public static T GetPrevious<T>(this IList<T> collection, T currentItem)
        {
            if (collection == null || collection.Count == 0)
                throw new ArgumentException("Collection cannot be null or empty.");
            int currentIndex = collection.IndexOf(currentItem);
            if (currentIndex <= 0) 
                return collection[collection.Count - 1];
            return collection[currentIndex - 1];
        }
    }
}
