using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EssentialCSharpPatentData;

namespace PatentDataAnalyzer
{
    public static class PatentDataAnalyzer
    {
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

        /// <summary>
        /// Returns only the last name of each of the inventor sorted in reverse order by inventor Id.
        /// </summary>
        /// <returns>The last name of each inventor</returns>
        public static IEnumerable<string> InventorLastNames()
        {
             IEnumerable <string> inventorLastNames =
                       from inventor in PatentData.Inventors
                       let lastName = inventor.Name.Split(' ').Last()
                       orderby inventor.Id descending
                       select lastName;
            return inventorLastNames;
        }

        /// <summary>
        /// Returns a single comma separated list of all the unique "State-Country" strings for each inventor. 
        /// The result should be a scalar value of type string, not a collection (other than the fact that a string is a collection of characters).
        /// </summary>
        /// <returns>A comma separated list of all the unique "State-Country" strings for each inventor</returns>
        public static string LocationsWithInventors()
        {
            return string.Join(", ", 
                (from inventor in PatentData.Inventors
                 select $"{inventor.State}-{inventor.Country}").Distinct().ToArray());   
        }

        /// <summary>
        /// Write a method that returns a collection of every nth fibonacci number.
        /// </summary>
        /// <param name="n">The number to calculate fibonacci to</param>
        /// <returns>A collection of every nth fibonacci number</returns>
        public static IEnumerable<int> NthFibbonacciNumbers(int n)
        {
            //unsure if I should return the number occuring at every
            //k*nth index, or all of the first n fibonacci numbers
            int[] fibs = new int[n];
            fibs[0] = 1;
            fibs[1] = 1;
            for (int index = 2; index < n; index++)
            {
                fibs[index] = fibs[index - 1] + fibs[index - 2];
            }
            return fibs;
        }

        


        /// <summary>
        /// Create a method that returns a list of inventors that have n patents, where n is provided as a parameter to the method.

        /// </summary>
        /// <param name="numberOfPatents">Number of patents each inventor must have</param>
        /// <returns>List of inventors that have n patents</returns>
        //public static List<Inventor> GetInventorsWithMultiplePatents(int numberOfPatents)
        //{
        //    return
        //        from patent in PatentData.Patents
        //        group patent by patent.InventorIds
        //        into groups
        //        select groups.Join(
        //            PatentData.Inventors,
        //            patent => patent.InventorIds,
        //            inventor => inventor.Id,
        //            (patent, inventors) =>
        //            {

        //            }

        //        );



        //}






    }
}
