using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3.Tests
{
    [TestClass]
    class RockPaperScissorsTests
    {
        [TestMethod]
        public void GetComputerChoice_ReturnsValidOption()
        {
            List<string> validOptions = new List<string> { "rock", "paper", "scissors" };
            for (int i = 0; i < 20; i++)
            {
                Assert.IsTrue(validOptions.Contains(Game.GetComputerChoice()));
            }
        }
    }
}
