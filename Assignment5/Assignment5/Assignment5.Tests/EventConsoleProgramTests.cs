using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment5;
using Assignment4;
using System.Collections.Generic;

namespace Assignment5.Tests
{
    [TestClass]
    public class EventConsoleProgramTests
    {

        [TestMethod]
        [DataRow("Something")]
        [DataRow(" ")]
        public void ContinuePrompt_ReturnsTrue(string input)
        {
            Assert.IsTrue(EventConsoleProgram.ContinueProgram(input));
        }

        [TestMethod]
        [DataRow("q")]
        [DataRow("quit")]
        [DataRow("exit")]
        public void ContinuePrompt_ReturnsFalse(string input)
        {
            Assert.IsFalse(EventConsoleProgram.ContinueProgram(input));
        }

        [TestMethod]
        public void TestAsCast_Success()
        {
            UniversityCourse u = new Assignment4.UniversityCourse(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0),
                "CSCD", "371", "Michaelis", "T Th");

            Event e = u as Event;
            if (e == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestAsCast_Failure()
        {
            Event e = new Assignment4.Event(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));

            UniversityCourse u = e as UniversityCourse;
            if (u != null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestIsCast()
        {
            UniversityCourse u = new Assignment4.UniversityCourse(
               ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0),
               "CSCD", "371", "Michaelis", "T Th");

            if (!(u is Event e))
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TestDirectCast()
        {
            UniversityCourse u = new Assignment4.UniversityCourse(
              ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0),
              "CSCD", "371", "Michaelis", "T Th");

            Event e = u;
            UniversityCourse sut = (UniversityCourse)e;
        
        }


    }
}


public class TestableConsole : IConsole
{
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