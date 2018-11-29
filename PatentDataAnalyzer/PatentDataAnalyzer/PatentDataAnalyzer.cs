using System;
using System.Collections.Generic;
using System.Linq;
using EssentialCSharpPatentData;

namespace PatentDataAnalyzer
{
    public static class PatentDataAnalyzer
    {
        /*
         * 

InventorNames: .
InventorLastNames: Returns the only the last name of each of the inventor sorted in reverse order by inventor Id.
LocationsWithInventors: Returns a single comma separated list of all the unique "-" strings for each inventor. The result should be a scalar value of type string, not a collection (other than the fact that a string is a collection of characters).
Randomize: Write an IEnumerable<T> extension method on a class called Enumerable<T> that returns an IEnumerable<T> of the original items in random order. To test execute the method using LINQ and verify the order is not the same for at least 3 invocations.
Extra Credit
GetInventorsWithMulitplePatents: Create a method that returns a list of inventors that have n patents, where n is provided as a parameter to the method.
NthFibonacciNumbers: Write a method that returns a collection of every nth fibonacci number.
         */

        /// <summary>
        /// Returns a list of the inventor names from the specified country where the country is specified as a parameter
        /// </summary>
        /// <param name="country">The specified country where the inventors are from</param>
        /// <returns>A List of names representing the inventors</returns>
        public static List<string> InventorNames(string country)
        {

            IEnumerable<string> inventors =
                from inventor in PatentData.Inventors
                where inventor.Country.Equals(country)
                select inventor.Name;
            return new List<string>(inventors);
        }

    }
}
