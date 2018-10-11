using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment3.Tests
{
    [TestClass]
    public class RockPaperScissorsTests
    {
        [DataRow(1, 2, 3)]
        [DataRow(0, 0, 0)]
        [DataRow(20, 15, 10)]
        [TestMethod]
        public void Constructor_TestAssignedDamage(int expRock, int expScis, int expPaper)
        {
            RockPaperScissors rps = new RockPaperScissors(expRock, expPaper, expScis);
            Assert.AreEqual(rps.ROCK.damage, expRock);
            Assert.AreEqual(rps.SCISSORS.damage, expScis);
            Assert.AreEqual(rps.PAPER.damage, expPaper);
        }

        [DataRow(20, "rock")]
        [DataRow(15, "scissors")]
        [DataRow(10, "paper")]
        [TestMethod]
        public void GetDamageByName(int dmg, string name)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.AreEqual(dmg, rps.GetDamageByName(name));
        }

        [DataRow("notfound")]
        [TestMethod]
        public void GetDamageByName_InvalidName_ThrowsArgumentException(string name)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.ThrowsException<ArgumentException>(() => rps.GetDamageByName(name));
        }

        [DataRow(1, "rock")]
        [DataRow(2, "scissors")]
        [DataRow(3, "paper")]
        [TestMethod]
        public void GetOrdinalByName(int ord, string name)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.AreEqual(ord, rps.GetOrdinalByName(name));
        }

        [DataRow("notfound")]
        [TestMethod]
        public void GetOrdinalByName_InvalidName_ThrowsArgumentException(string name)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.ThrowsException<ArgumentException>(() => rps.GetOrdinalByName(name));
        }

        [DataRow(1, 2, -1)]
        [DataRow(1, 3, 1)]
        [DataRow(1, 1, 0)]
        [TestMethod]
        public void Compare_Rock_LHS(int RockOrdinal, int other, int expectedResult)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.AreEqual(expectedResult, RockPaperScissors.Compare(RockOrdinal, other));
        }

        [DataRow(2, 2, 0)]
        [DataRow(2, 3, -1)]
        [DataRow(2, 1, 1)]
        [TestMethod]
        public void Compare_Scissors_LHS(int RockOrdinal, int other, int expectedResult)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.AreEqual(expectedResult, RockPaperScissors.Compare(RockOrdinal, other));
        }

        [DataRow(3, 2, 1)]
        [DataRow(3, 3, 0)]
        [DataRow(3, 1, -1)]
        [TestMethod]
        public void Compare_Paper_LHS(int RockOrdinal, int other, int expectedResult)
        {
            RockPaperScissors rps = new RockPaperScissors();
            Assert.AreEqual(expectedResult, RockPaperScissors.Compare(RockOrdinal, other));
        }

    }
}
