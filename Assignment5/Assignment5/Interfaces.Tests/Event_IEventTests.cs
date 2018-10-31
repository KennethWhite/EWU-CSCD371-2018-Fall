using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Assignment5.Tests
{
    [TestClass]
    public class Event_IEventTests
    {

        private static Assignment4.Event Event { get; set; }

        [TestInitialize]
        public void SetupEvent()
        {
            Event = new Assignment4.Event(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0));
        }

        [TestMethod]
        public void GetStartDate_ReturnsValue()
        {
            IEvent e = Event;
            Assert.AreEqual(new DateTime(2018, 10, 14, 14, 0, 0), e.GetStartDate());
        }

        [TestMethod]
        public void GetEndDate_ReturnsValue()
        {
            IEvent e = Event;
            Assert.AreEqual(new DateTime(2018, 10, 14, 16, 30, 0), e.GetEndDate());
        }
    }
}
