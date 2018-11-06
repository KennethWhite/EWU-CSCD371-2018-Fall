using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment6;

namespace Assignment6.Tests
{
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        [DataRow("Monday", DaysOfWeek.Monday)]
        [DataRow("Wednesday", DaysOfWeek.Wednesday)]
        [DataRow("Saturday", DaysOfWeek.Saturday)]
        public void ParseDayOfWeek_SingleDay(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<DaysOfWeek>(input, out DaysOfWeek day);
            Assert.IsTrue(day.HasFlag(expectedFlag));

        }

        [TestMethod]
        [DataRow("Monday, Tuesday", DaysOfWeek.Monday | DaysOfWeek.Tuesday)]
        [DataRow("Wednesday, Friday", DaysOfWeek.Wednesday | DaysOfWeek.Friday)]
        [DataRow("Sunday, Thursday", DaysOfWeek.Sunday | DaysOfWeek.Thursday)]
        public void ParseDayOfWeek_MultipleDays(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<DaysOfWeek>(input, out DaysOfWeek day);
            Assert.IsTrue(day.HasFlag(expectedFlag));
        }

        [TestMethod]
        public void ParseDayOfWeek_AllDays()
        {
            string input = "Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday";
            System.Enum expectedFlag = DaysOfWeek.Sunday | DaysOfWeek.Monday |
                DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday
                | DaysOfWeek.Friday | DaysOfWeek.Saturday;

            Enum.TryParse<DaysOfWeek>(input, out DaysOfWeek day);
            Assert.IsTrue(day.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Monday, Tuesday", DaysOfWeek.Friday | DaysOfWeek.Tuesday)]
        [DataRow("Wednesday, Friday", DaysOfWeek.Saturday)]
        public void ParseDayOfWeek_FlagsDontMatch(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<DaysOfWeek>(input, out DaysOfWeek day);
            Assert.IsFalse(day.HasFlag(expectedFlag));
        }


        [TestMethod]
        [DataRow("Winter", Quarter.Winter)]
        [DataRow("Spring", Quarter.Spring)]
        [DataRow("Summer", Quarter.Summer)]
        [DataRow("Fall", Quarter.Fall)]
        public void ParseQuarter_OneQuarter(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<Quarter>(input, out Quarter q);
            Assert.IsTrue(q.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Winter, Spring", Quarter.Winter | Quarter.Spring)]
        [DataRow("Summer, Fall", Quarter.Summer | Quarter.Fall)]
        [DataRow("Winter, Fall, Spring, Summer", 
            Quarter.Summer | Quarter.Fall | Quarter.Spring | Quarter.Winter)]
        public void ParseQuarter_MultipleQuarters(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<Quarter>(input, out Quarter q);
            Assert.IsTrue(q.HasFlag(expectedFlag));
        }


        [TestMethod]
        [DataRow("Winter", Quarter.Spring)]
        [DataRow("Spring", Quarter.Winter)]
        [DataRow("Fall, Spring", Quarter.Fall | Quarter.Winter | Quarter.Spring)]
        public void ParseQuarter_FlagsDontMatch(string input, System.Enum expectedFlag)
        {
            Enum.TryParse<Quarter>(input, out Quarter q);
            Assert.IsFalse(q.HasFlag(expectedFlag));
        }
    }
}
