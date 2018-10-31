using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment5.Tests
{
    [TestClass]
    public class EventConsole_IConsoleTests
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
            Assert.AreEqual(line, MyConsole.ReadLine());

        }

        [TestMethod]
        [DataRow("TEST_VALUE")]
        [DataRow("C#")]
        [DataRow("Rocks")]
        public void EventWriteLine_WritesString(string line)
        {
            MyConsole.WriteLine(line);
            Assert.AreEqual(line, MyConsole.LastWrittenLine);
        }

        [TestMethod]
        [DataRow("TEST_VALUE")]
        [DataRow("C#")]
        [DataRow("Rocks")]
        public void TestConsoleOutput(string line)
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Console.WriteLine(line);
            Console.SetOut(Console.Out);

            Assert.AreEqual(sw.ToString(), line + Environment.NewLine);
        }

        [TestMethod]
        [DataRow("TEST_VALUE")]
        [DataRow("C#")]
        [DataRow(" ")]
        public void TestConsoleIn(string line)
        {
            StringReader sr = new StringReader(line);
            Console.SetIn(sr);
            string result = Console.ReadLine();
            Console.SetIn(Console.In);
            Assert.AreEqual(result, line);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void TestEmptyString_NewlinePrinted(string line)
        {
            MyConsole.WriteLine(line);
            Assert.AreEqual(Environment.NewLine, MyConsole.LastWrittenLine);
        }

    }

    public class TestableConsole : IConsole {
        public string LastWrittenLine { get; private set; }
        public List<string> LinesToRead { get; set; }

        public string ReadLine()
        {
            string ret = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return ret;
        }

        public void WriteLine(string line)
        {
            //Empty strings advance the console window to the next line
            LastWrittenLine = (string.IsNullOrEmpty(line)) ? Environment.NewLine : line;
        }

    }
}
