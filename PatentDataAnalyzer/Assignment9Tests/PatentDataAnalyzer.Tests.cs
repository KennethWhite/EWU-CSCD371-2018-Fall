using Microsoft.VisualStudio.TestTools.UnitTesting;
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


    }
}
