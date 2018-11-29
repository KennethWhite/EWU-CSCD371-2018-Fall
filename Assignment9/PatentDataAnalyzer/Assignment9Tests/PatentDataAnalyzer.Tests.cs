using EssentialCSharpPatentData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PatentDataAnalyzer;

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
            foreach(string name in lastNames)
            {
                Assert.IsTrue(validLastNames.Contains(name), $"Could not find {name} in valid names.");
            }
            
        }

        [TestMethod]
        public void InventorLastNames_ReturnsNamesInReverseOrderById()
        {
            IEnumerable<string> lastNames = PatentDataAnalyzer.PatentDataAnalyzer.InventorLastNames();
            int index = PatentData.Inventors.Length-1;
            var expectedOrder = PatentData.Inventors.OrderByDescending(x => x.Id);
            //sequence equals
            foreach(string name in lastNames)
            {
                Assert.IsTrue(PatentData.Inventors[index].Name.EndsWith(name), "");
                index--;
            }
        }

        [TestMethod]
        public void LocationsWithInventors_ReturnsDistinctList()
        {
            string result = PatentDataAnalyzer.PatentDataAnalyzer.LocationsWithInventors();
            string[] locations = result.Split(", ");
            //List<string> locationsList = new List<string>(locations);
            //this doesnt make sense logically
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
                //this is doing multiple executions. Just store the list in a List variable
                Assert.IsFalse(randomizedList.SequenceEqual(PatentData.Inventors));
                Assert.IsFalse(randomizedList.SequenceEqual(prevList));
                prevList = randomizedList;
            }
        }

        [TestMethod]
        public void NthFibonacciNumbers_ReturnsFibonacciSequenceToN()
        {
            Assert.Fail();
            List<int> fibs = new List<int>
            {
                1,1,2,3,5,8,13,21,34,55,89,144
            };

            int[] results = PatentDataAnalyzer.PatentDataAnalyzer.NthFibbonacciNumbers(fibs.Count).ToArray();
            for (int n = 0; n < fibs.Count; n++)
            {
                Assert.AreEqual(fibs[n], results[n]);
            }
        }

    }
}
