using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Assignment3.Game;

namespace Assignment3.Tests
{
    [TestClass]
    public class GameTests
    {
        [DataRow(false, "flub")]
        [DataRow(false, "incorrect")]
        [DataRow(false, "")]
        [TestMethod]
        public void GetUserChoice_InvalidInput_ReturnsFalse(bool expected, string input)
        {
            bool result = CheckUserChoice(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetUserChoice_NullInput_ReturnsFalse()
        {
            bool result = CheckUserChoice(null);
            Assert.IsFalse(false);
        }

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

        [DataRow(1, 100, "Human", 100, "Computer")]
        [DataRow(23, 10, "Kenny", 55, "Bob")]
        [DataRow(-123, 11, "h", 11, "c")]
        [TestMethod]
        public void PrintStatus_OutputMatchesExpected(int round, int hHealth, string hName, int cHealth, string cName)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);
            Player h = new Player(n: hName, h: hHealth);
            Player c = new Player(n: cName, h: cHealth);
            PrintStatus(round, h, c);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"\nRound {round}:");
            expected.AppendLine($"Round {h.Name}: {h.Health} health");
            expected.AppendLine($"Round {c.Name}: {c.Health} health");

            Assert.AreEqual(expected.ToString(), sb.ToString());
        }

        [DataRow("rock", "human", "scissors", "computer", 20)]
        [DataRow("scissors", "Kenny", "paper", "computer", 15)]
        [DataRow("paper", "Bob", "rock", "computer", 10)]
        [TestMethod]
        public void PrintRoundResult_OutputMatchesExpected(
            string winMove, string winName, string losMove, string losName, int dmgTaken)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);
            Player w = new Player(n: winName, lm: winMove);
            Player l = new Player(n: losName, lm: losMove);
            PrintRoundResult((w, l, dmgTaken));

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"{w.Name} used {w.LastMove} vs " +
                   $"{l.Name}'s {l.LastMove}.");
            expected.AppendLine($"Result: {l.Name} takes {dmgTaken} damage from {w.LastMove}!");

            Assert.AreEqual(expected.ToString(), sb.ToString());
        }

        [DataRow("rock", "human", "rock", "computer", 0)]
        [TestMethod]
        public void PrintRoundResult_Draw_OutputMatchesExpected(
            string winMove, string winName, string losMove, string losName, int dmgTaken)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);
            Player w = new Player(n: winName, lm: winMove);
            Player l = new Player(n: losName, lm: losMove);
            PrintRoundResult((w, l, dmgTaken));

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"{w.Name} used {w.LastMove} vs " +
                   $"{l.Name}'s {l.LastMove}.");
            expected.AppendLine($"Result: Draw!");

            Assert.AreEqual(expected.ToString(), sb.ToString());
        }

    }
}
