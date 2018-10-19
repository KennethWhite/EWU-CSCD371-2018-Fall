using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Assignment4.EventLibrary;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EventLibrary.Tests
{
    [TestClass]
    public class EventLibraryTests
    {

        private static Assignment4.UniversityCourse Course { get; set; }
        private static Assignment4.Event Event { get; set; }
        
        [TestInitialize]
        public void SetUp()
        {
            Course = new Assignment4.UniversityCourse(
             ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0),
             "CSCD", "371", "Michaelis", "T Th");

            Event = new Assignment4.Event(
                "Rock Em Sockem Robots", "EWU", new DateTime(2018, 10, 14, 8, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));
        }

        [TestMethod]
        public void Display_Event_ReturnsSummary()
        {
            Assert.AreEqual(Display(Event), Event.GetSummaryInformation());
        }

        [TestMethod]
        public void Display_UniversityCourse_ReturnsSummary()
        {
            Assert.AreEqual(Display(Course), Course.GetSummaryInformation());
        }

        [TestMethod]
        [DataRow(12.55)]
        [DataRow("someString")]
        public void Display_UnknownObject_ReturnsToString(object o)
        {
            Assert.AreEqual(o.ToString(), Display(o));
        }


        [TestMethod]
        public void Display_List_ReturnsSummary()
        {
            string expected = Event.GetSummaryInformation();
            expected += Course.GetSummaryInformation();

            List<Assignment4.Event> l = new List<Assignment4.Event>();
            l.Add(Event);
            l.Add(Course);
            Assert.AreEqual(expected, Display<Assignment4.Event>(l));
        }

    }
}
