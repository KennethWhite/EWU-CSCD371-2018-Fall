using EssentialCSharpPatentData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PatentDataAnalyzer;
using System;

namespace Assignment9Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [TestMethod]
        public void InventorNames_InvalidCountry_ListEmpty()
        {
            Assert.IsTrue(PatentDataAnalyzer.PatentDataAnalyzer.InventorNames("Timbuktu").Count == 0);
        }

        [TestMethod]
        [DataRow("USA", 6)]
        [DataRow("UK", 1)]
        public void InventorNames_ValidCountry_ListContainsCorrectNumber(string country, int expected)
        {
            Assert.AreEqual(expected, PatentDataAnalyzer.PatentDataAnalyzer.InventorNames(country).Count);
        }

        [TestMethod]
        public void InventorLastNames_ReturnsLastName()
        {
            List<string> validLastNames = new List<string>
            {
                "Wright",
                "Franklin",
                "Stephenson",
                "Morse",
                "Michaelis",
                "Jacob"
            };
            IEnumerable<string> lastNames = PatentDataAnalyzer.PatentDataAnalyzer.InventorLastNames();
            foreach (string name in lastNames)
            {
                Assert.IsTrue(validLastNames.Contains(name), $"Could not find {name} in valid names.");
            }

        }

        [TestMethod]
        public void InventorLastNames_ReturnsNamesInReverseOrderById()
        {
            IEnumerable<string> lastNames = PatentDataAnalyzer.PatentDataAnalyzer.InventorLastNames();
            int index = PatentData.Inventors.Length - 1;
            var expectedOrder = PatentData.Inventors.OrderByDescending(x => x.Id);
            //sequence equals
            foreach (string name in lastNames)
            {
                Assert.IsTrue(PatentData.Inventors[index].Name.EndsWith(name), "");
                index--;
            }
        }

        [TestMethod]
        public void LocationsWithInventors_ReturnsDistinctList()
        {
            string result = PatentDataAnalyzer.PatentDataAnalyzer.LocationsWithInventors();
            string[] resultLocations = result.Split(", ");
            Inventor[] inventors = PatentData.Inventors;
            List<string> locationsList = new List<string>(inventors.Select(inventor => $"{inventor.State}-{inventor.Country}"));
            foreach (string location in locationsList)
            {
                Assert.IsTrue(
                    resultLocations.Where(loc => loc != null && loc.Equals(location)).Count() == 1,
                    $"Failed : {location}");
            }
        }

        [TestMethod]
        public void Randomize_ReturnsNewOrderThreeConsecutiveTimes_Success()
        {
            IEnumerable<Inventor> prevList = new List<Inventor>();
            for (int iteration = 0; iteration < 3; iteration++)
            {
                IEnumerable<Inventor> randomizedList =
                PatentDataAnalyzer.Enumerable.Randomize<Inventor>(PatentData.Inventors);
                //this is doing multiple executions. Just store the list in a List variable
                Assert.IsFalse(randomizedList.SequenceEqual(PatentData.Inventors));
                Assert.IsFalse(randomizedList.SequenceEqual(prevList));
                prevList = randomizedList;
            }
        }

        [TestMethod]
        [DataRow(1,new int[] {1, 1, 2, 3} )]
        [DataRow(2,new int[] {1, 3, 8, 21} )]
        [DataRow(3,new int[] {2, 8, 34, 144} )]
        public void NthFibonacciNumbers_ReturnsFibonacciSequenceToN(int n, int[] expected)
        {
     
            List<int> fibs = new List<int>
            {
                1,1,2,3,5,8,13,21,34,55,89,144
            };

            List<int> results = 
                PatentDataAnalyzer.PatentDataAnalyzer.NthFibonacciNumbers(n).Take(expected.Length).ToList();
            Assert.IsTrue(results.SequenceEqual(expected),
                $"Expected : {expected}{Environment.NewLine}" +
                $"Actual : {results}");
        }

        [TestMethod]
        [DataRow(1, 6)]
        [DataRow(2, 0)]
        [DataRow(3, 1)]
        public void GetInventorsWithMultiplePatents_ResultsHaveMultiplePatents(int numOfPatents, int expectedNumberOfResults)
        {
            //Not an elegant way to test this, relies on the dataset not changing.
            List<Inventor> results = PatentDataAnalyzer.PatentDataAnalyzer.GetInventorsWithMultiplePatents(numOfPatents);
            Assert.AreEqual(expectedNumberOfResults, results.Count);
        }


    }
}
