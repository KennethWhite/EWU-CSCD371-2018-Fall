using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Event.Tests
{
    [TestClass]
    public class EventTests
    {

        private static Assignment4.Event Event { get; set; }

        [TestInitialize]
        public void SetupUnivCourse()
        {
            Event = new Assignment4.Event(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));
        }

        [TestMethod]
        public void Event_TestConstructor_ObjectCreated()
        {
            Assignment4.Event e = new Assignment4.Event("TEST", "TEST", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));
        }

        [TestMethod]
        public void GetTitle_ReturnsValue()
        {
            Assert.AreEqual(".Net GUI", Event.Title);
        }

        [TestMethod]
        public void SetTitle_TitleUpdated()
        {
            Event.Title = "TEST_VALUE";
            Assert.AreEqual("TEST_VALUE", Event.Title);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("        ")]
        [DataRow("S")]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTitle_InvalidData_ThrowsException(string test)
        {
            Event.Title = test;
            Assert.Fail();
        }

        [TestMethod]
        public void GetLocation_ReturnsValue()
        {
            Assert.AreEqual("CEB 207", Event.Location);
        }

        [TestMethod]
        public void SetLocation_LocationUpdated()
        {
            Event.Location = "TEST_VALUE";
            Assert.AreEqual("TEST_VALUE", Event.Location);
        }

        [TestMethod]
        public void GetStartDate_ReturnsValue()
        {
            Assert.AreEqual(new DateTime(2018, 10, 14, 14, 0, 0), Event.StartDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDate_EndDateBeforeStartDate_ThrowsException()
        {
            Assignment4.Event e = new Assignment4.Event(
                ".Net GUI", "CEB 207",
                new DateTime(2018, 10, 14, 14, 0, 0),
                new DateTime(2018, 10, 14, 10, 30, 0));
            Assert.Fail();
        }

        [TestMethod]
        public void GetEventsCreated_ReturnsIncrementedValue()
        {
            int count = Assignment4.Event.EventsCreated;
            Assignment4.Event e = new Assignment4.Event(".Net GUI", "CEB 207", 
                new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));
            Assert.AreEqual(count+1, Assignment4.Event.EventsCreated);
        }

    }
}
