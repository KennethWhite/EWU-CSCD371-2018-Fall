using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment6;
using System.Runtime.InteropServices;

namespace Assignment6.Tests
{
    [TestClass]
    public class ScheduleStructTests
    {

        private Schedule _Schedule { get; set; }
        private TimeValue _TimeValue { get; set; }

        [TestInitialize]
        public void SetupStructs()
        {
            _TimeValue = new TimeValue(14, 0, 0);
            _Schedule = new Schedule(
                DaysOfWeek.Tuesday | DaysOfWeek.Thursday,
                Quarter.Fall,
                _TimeValue,
                new TimeSpan(2, 30, 0));
        }


        [TestMethod]
        public void Schedule_MarshallSize_LEQTo16Bytes()
        {
            int size = Marshal.SizeOf<Schedule>(_Schedule);
            Assert.AreEqual("16", size.ToString()); //easy to see failure by casting
        }

        [TestMethod]
        public void TimeValue_MarshallSize_LEQTo16Bytes()
        {
            int size = Marshal.SizeOf<TimeValue>(_TimeValue);
            Assert.IsTrue(16 >= size);
        }

        //This does not compile since Schedule structs are readonly
        //[TestMethod]
        //public void Assert_Readonly()
        //{
        //    _Schedule.StartTime = new TimeValue(0, 0, 0);
        //}
    }
}
