using EssentialCSharpPatentData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PatentDataAnalyzerRef = PatentDataAnalyzer.PatentDataAnalyzer;

namespace Assignment9Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [TestMethod]
        public void InventorNames_InvalidCountry_ListEmpty()
        {
            Assert.IsTrue(PatentDataAnalyzerRef.InventorNames("Timbuktu").Count == 0);
        }

        [TestMethod]
        [DataRow("USA", 6)]
        [DataRow("UK", 1)]
        public void InventorNames_ValidCountry_ListContainsCorrectNumber(string country, int expected)
        {
            Assert.AreEqual(expected, PatentDataAnalyzerRef.InventorNames(country).Count);
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
            IEnumerable<string> lastNames = PatentDataAnalyzerRef.InventorLastNames();
            foreach(string name in lastNames)
            {
                Assert.IsTrue(validLastNames.Contains(name));
            }
        }

        [TestMethod]
        public void InventorLastNames_ReturnsNamesInReverseOrderById()
        {
            IEnumerable<string> lastNames = PatentDataAnalyzerRef.InventorLastNames();
            int currentID = PatentData.Inventors.Length-1;
            foreach(string name in lastNames)
            {
                Assert.IsTrue(PatentData.Inventors[currentID].Name.Contains(name));
                currentID--;
            }
        }

        [TestMethod]
        public void LocationsWithInventors_ReturnsDistinctList()
        {
            string result = PatentDataAnalyzerRef.LocationsWithInventors();
            string[] locations = result.Split(", ");
            List<string> locationsList = new List<string>(locations);
            foreach(string location in locationsList)
            {
                Assert.IsTrue(
                    locationsList.Where(loc => loc != null && loc.Equals(location)).Count() == 1);
            }
        }

        [TestMethod]
        public void Randomize_ReturnsNewOrderThreeConsecutiveTimes_Success()
        {
            IEnumerable<Inventor> prevList = new List<Inventor>();
            for (int iteration = 0; iteration < 3; iteration++ )
            {
                IEnumerable<Inventor> randomizedList =
                PatentDataAnalyzer.Enumerable.Randomize<Inventor>(PatentData.Inventors);
                Assert.IsFalse(randomizedList.SequenceEqual(PatentData.Inventors));
                Assert.IsFalse(randomizedList.SequenceEqual(prevList));
                prevList = randomizedList;
            }
        }

        [TestMethod]
        public void NthFibonacciNumbers_ReturnsFibonacciSequenceToN()
        {
            List<int> fibs = new List<int>
            {
                1,1,2,3,5,8,13,21,34,55,89,144
            };

            int[] results = PatentDataAnalyzerRef.NthFibbonacciNumbers(fibs.Count).ToArray();
            for (int n = 0; n < fibs.Count; n++)
            {
                Assert.AreEqual(fibs[n], results[n]);
            }
        }

    }
}
