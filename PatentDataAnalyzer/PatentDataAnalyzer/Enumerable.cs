using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9
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
            List<T> items = new List<T>();
            foreach (T item in collection)
            {
                items.Add(item);
            }
            int count = items.Count;
            Random rng = new Random();
            while (count > 1)
            {
                count--;
                int k = rng.Next(count + 1);
                T value = items[k];
                items[k] = items[count];
                items[count] = value;
            }
            return items;
        }
    }
}
