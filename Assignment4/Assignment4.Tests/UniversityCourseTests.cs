using Assignment4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UniversityCourse.Tests
{
    [TestClass]
    public class UniversityCourseTests
    {
        [TestMethod]
        public void UniversityCourse_CallConstructor_ObjectCreated()
        {
            Assignment4.UniversityCourse course = new Assignment4.UniversityCourse(
                ".Net GUI", "CEB 207" , new DateTime(2018, 10, 14, 2, 0, 0), new DateTime(2018, 10, 14, 4, 30, 0),
                "CSCD", "371", "Michaelis", "T Th");
        }

        [DataRow("CSCD", ".Net GUI", "CEB 207", "371", "Michaelis", "T Th")]
        [TestMethod]
        public void UniversityCourse_Dec_ObjectCreated(string dep, string title, string location, string id, string instructor, string daysOfWeek)
        {
            DateTime start = new DateTime(2018, 10, 14, 2, 0, 0);
            DateTime end = new DateTime(2018, 10, 14, 4, 30, 0);
            Assignment4.UniversityCourse course = new Assignment4.UniversityCourse(
                title, location, start, end, dep, id, instructor, daysOfWeek);
            (string t, string l, string i, DateTime s, DateTime e) = course;
            Assert.AreEqual(t, $"{dep} {id}");
            Assert.AreEqual(l, location);
            Assert.AreEqual(i, instructor);
            Assert.AreEqual(s, start);
            Assert.AreEqual(e, end);
        }

    }
}
