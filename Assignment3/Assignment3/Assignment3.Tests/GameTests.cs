using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static Assignment3.Game;

namespace Assignment3.Tests
{
    [TestClass]
    public class GameTests
    {
        //[DataRow(false, "flub")]
        //[TestMethod]
        //public void GetUserChoice_InvalidInput_ReturnsFalse(bool expected, string input)
        //{

        //    string expectedOutput = $@"Pick your choice; rock, paper, or scissors: <<{input}";
        //    IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Game.GetUserChoice(out string line))
        //}

        [TestMethod]
        public void GetComputerChoice_ReturnsValidOption()
        {
            List<string> validOptions = new List<string> { "rock", "paper", "scissors" };
            for (int i = 0; i < 20; i++)
            {
                Assert.IsTrue(validOptions.Contains(Game.GetComputerChoice()));
            } 
        }

        [DataRow("rock", "paper", 10)]
        [DataRow("rock", "scissors", 20)]
        [DataRow("scissors", "paper", 15)]
        [DataRow("scissors", "scissors", 0)]
        [TestMethod]
        public void EvaluateRound_AssertWinnerDamageCorrect(string hLastMove, string cLastMove, int expectedDamage)
        {
            Player h = new Player(lm: hLastMove);
            Player c = new Player(lm: cLastMove);
            RockPaperScissors rps = new RockPaperScissors();
            (Player w, Player l, int damage) = EvaluateRound(h,c, rps);
            Assert.AreEqual(expectedDamage, damage);
        }

        [DataRow("rock", "paper", "Player")]
        [DataRow("rock", "scissors", "Human")]
        [DataRow("scissors", "paper", "Human")]
        [DataRow("scissors", "scissors", "Human")]
        [TestMethod]
        public void EvaluateRound_AssertWinnerNameCorrect(string hLastMove, string cLastMove, string expectedName)
        {
            Player h = new Player(n: "Human", lm: hLastMove);
            Player c = new Player(lm: cLastMove);
            RockPaperScissors rps = new RockPaperScissors();
            (Player w, Player l, int damage) = EvaluateRound(h, c, rps);
            Assert.AreEqual(w.Name, expectedName);
        }

        [DataRow(10, 90)]
        [DataRow(20, 80)]
        [DataRow(15, 85)]
        [DataRow(0, 100)]
        [TestMethod]
        public void UpdateHealth_AssertLoserHealthCorrect(int dmg, int expectedHealth)
        {
            Player h = new Player(h: 100);
            Player c = new Player(h: 100);
            (Player w, Player l, int damage) result = (h, c, dmg);
            UpdateHealth(result, out h, out c);
            Assert.AreEqual(expectedHealth, c.Health);
        }

        [DataRow(10, 100)]
        [DataRow(20, 100)]
        [DataRow(15, 100)]
        [DataRow(0, 100)]
        [TestMethod]
        public void UpdateHealth_AssertWinnerHealthCorrect(int dmg, int expectedHealth)
        {
            Player h = new Player(h: 100);
            Player c = new Player(h: 100);
            (Player w, Player l, int damage) result = (h, c, dmg);
            UpdateHealth(result, out h, out c);
            Assert.AreEqual(expectedHealth, h.Health);
        }

        [DataRow(10, 100, false)]
        [DataRow(0, 100, true)]
        [DataRow(100, 0, true)]
        [DataRow(-14, -25100, true)]
        [TestMethod]
        public void GameIsOver_ReturnTrueHealthLEQ0(int hHealth, int cHealth, bool expected)
        {
            Player h = new Player(h: hHealth);
            Player c = new Player(h: cHealth);
            Assert.AreEqual(expected, GameIsOver(h, c));
        }



    }
}
