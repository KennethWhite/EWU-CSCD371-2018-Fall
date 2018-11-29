using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatentDataAnalyzer
{
    public static class Enumerable
    {
        /// <summary>
        /// Randomize: Write an IEnumerable<T> extension method on a class called Enumerable<T> 
        /// that returns an IEnumerable<T> of the original items in random order. 
        ///  To test execute the method using LINQ and verify the order is not the same for at least 3 invocations.
        /// </summary>
        /// <typeparam name="T">Type parameter of IEnumerable</typeparam>
        /// <param name="collection">The collection to be randomized</param>
        /// <returns>An IEnumerable representing the newly ordered collection</returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection)
        {
            List<T> items = collection.ToList();
            int count = items.Count;
            Random rng = new Random();

            while (items.Any())
            {
                int index = rng.Next(items.Count);
                T item = items[index];
                items.RemoveAt(index);
                yield return item;
            }

            //while (count > 1)
            //{
            //    count--;
            //    int k = rng.Next(count + 1);
            //    T value = items[k];
            //    items[k] = items[count];
            //    items[count] = value;
            //}
            //return items;
        }
    }
}
