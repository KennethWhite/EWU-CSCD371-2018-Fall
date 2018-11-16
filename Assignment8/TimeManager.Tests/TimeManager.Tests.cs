using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/* The TimeManager class was rather difficult to test, probably because of the way I implemented it
 * 
 * In particular any tests that tried to show my TimeManager.ElapsedTimed was greated than 0 failed.
 * Debugging these test methods took long enough these tests did pass and so I tried to 
 * use System.Threading.Thread.Sleep() to allow time to pass, but this did not work, even with larger
 * values 5+ seconds
 *
 */

namespace EventTimer.Tests
{
    [TestClass]
    public class TimeManagerTests
    {

        private TestableDateTime MyDateTime { get; set; }
        private TimeManager MyTimeManager { get; set; }
        private string TestEventResult { get; set; }

        [TestInitialize]
        public void InitializeMyDateTime()
        {
            TestEventResult = "Fail";
            MyDateTime = new TestableDateTime();
            MyTimeManager = new TimeManager(StopTimerCallEvent);
        }

        private void StopTimerCallEvent(TimeManager.TimeEvent timeEvent)
        {
            TestEventResult = timeEvent.Description;
        }

        [TestMethod]
        public void TestGetTimeNow_ReturnsDate()
        {
            MyDateTime.ListOfDates = new List<DateTime>
            {
                new DateTime(2018, 11, 15),
                new DateTime(2020, 6, 6)
            };
            Assert.AreEqual(new DateTime(2018, 11, 15), MyDateTime.GetDateTimeNow());
            Assert.AreEqual(new DateTime(2020, 6, 6), MyDateTime.GetDateTimeNow());
        }

        [TestMethod]
        public void ConstructTimeManager_CurrentTimeSet()
        {
            DateTime before = DateTime.Now;
            System.Threading.Thread.Sleep(1);
            TimeManager sut = new TimeManager(StopTimerCallEvent);
            Assert.IsTrue(sut.CurrentTime > before);
        }

        [TestMethod]
        public void ConstructTimeManager_CurrentTimeTicking()
        {
            Assert.IsTrue(MyTimeManager.ClockTimerIsTicking());
        }

        [TestMethod]
        public void StartEventTimer_EventTimerNotTicking()
        {
            Assert.IsFalse(MyTimeManager.EventTimerIsTicking());
        }

        [TestMethod]
        public void StartEventTimer_EventTimerTicking()
        {
            MyTimeManager.StartTimer();
            Assert.IsTrue(MyTimeManager.EventTimerIsTicking());
        }


        [TestMethod]
        public void EndTimer_EventCalled_ParameterPassed()
        {
            MyTimeManager.StartTimer();
            MyTimeManager.EndTimer("Pass");
            Assert.AreEqual("Pass", TestEventResult);
        }

        

    }

    class TestableDateTime : IDateTime.IDateTime
    {
        public List<DateTime> ListOfDates { get; set; }

        public DateTime GetDateTimeNow()
        {
            DateTime ret = ListOfDates[0];
            ListOfDates.RemoveAt(0);
            return ret;
        }
    }
}
