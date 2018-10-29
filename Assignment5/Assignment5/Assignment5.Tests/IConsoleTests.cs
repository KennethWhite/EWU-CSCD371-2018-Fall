using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment5.Tests
{
    [TestClass]
    public class IConsoleTests
    {

        TestableConsole MyConsole { get; set; }

        [TestInitialize]
        public void InitializeConsole()
        {
            MyConsole = new TestableConsole();
        }

        [TestMethod]
        [DataRow("TEST_VALUE")]
        [DataRow("C#")]
        [DataRow("Rocks")]
        public void EventReadLine_ReturnsString(string line)
        {
            MyConsole.LinesToRead = new List<string>
            {
                line
            };
            Assert.AreEqual(line, MyConsole.EventReadLine());

        }

        [TestMethod]
        [DataRow("TEST_VALUE")]
        [DataRow("C#")]
        [DataRow("Rocks")]
        public void EventWriteLine_WritesString(string line)
        {
            MyConsole.EventWriteLine(line);
            Assert.AreEqual(line, MyConsole.LastWrittenLine);
        }

    }

    public class TestableConsole : IConsole {
        public string LastWrittenLine { get; private set; }
        public List<string> LinesToRead { get; set; }

        public string EventReadLine()
        {
            string ret = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return ret;
        }

        public void EventWriteLine(string line)
        {
            LastWrittenLine = line;
        }

    }
}
