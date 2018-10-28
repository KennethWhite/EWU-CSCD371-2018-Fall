using Assignment4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UniversityCourse.Tests
{
    [TestClass]
    public class UniversityCourseTests
    {
        private static Assignment4.UniversityCourse Course{ get; set;}

        [TestInitialize]
        public void SetupUnivCourse()
        {
            Course = new Assignment4.UniversityCourse(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 14, 0, 0), new DateTime(2018, 10, 14, 16, 30, 0),
                "CSCD", "371", "Michaelis", "T Th");
        }

        [TestMethod]
        public void UniversityCourse_CallConstructor_ObjectCreated()
        {
            Assignment4.UniversityCourse course = new Assignment4.UniversityCourse(
                ".Net GUI", "CEB 207" , new DateTime(2018, 10, 14, 2, 0, 0), new DateTime(2018, 10, 14, 4, 30, 0),
                "CSCD", "371", "Michaelis", "T Th");
        }

        [DataRow("CSCD", ".Net GUI", "CEB 207", "371", "Michaelis", "T Th")]
        [TestMethod]
        public void UniversityCourse_Deconstruct_ParametersInitialized(string dep, string title, string location, string id, string instructor, string daysOfWeek)
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

        [TestMethod]
        public void GetTitle_OverridesBase_ReturnsOverriddenFormat()
        { 
            Assert.AreEqual($"{Course.Department} {Course.CourseID}", Course.Title);
        }

        [TestMethod]
        public void GetDepartment_ReturnsValue()
        {
            Assert.AreEqual($"CSCD", Course.Department);
        }

        [TestMethod]
        public void SetDepartment_DepartmentValueChanged()
        {
            Course.Department = "TEST_VALUE";
            Assert.AreEqual($"TEST_VALUE", Course.Department);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("        ")]
        [DataRow("S")]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDepartment_InvalidData_ThrowException(string test)
        {
            Course.Department = test;
            Assert.Fail();
        }


        [TestMethod]
        public void GetCourseID_ReturnsValue()
        {
            Assert.AreEqual($"371", Course.CourseID);
        }

        [TestMethod]
        public void SetCourseID_CourseIDValueChanged()
        {
            Course.CourseID = "TEST_VALUE";
            Assert.AreEqual($"TEST_VALUE", Course.CourseID);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("        ")]
        [DataRow("S")]
        [ExpectedException(typeof(ArgumentException))]
        public void SetCourseID_InvalidData_ThrowException(string test)
        {
            Course.CourseID = test;
            Assert.Fail();
        }



        [TestMethod]
        public void GetInstructor_ReturnsValue()
        {
            Assert.AreEqual($"Michaelis", Course.Instructor);
        }

        [TestMethod]
        public void SetInstructor_InstructorValueChanged()
        {
            Course.Instructor = "TEST_VALUE";
            Assert.AreEqual($"TEST_VALUE", Course.Instructor);
        }

        [TestMethod]
        public void GetSchedule_ReturnsValue()
        {
            Assert.AreEqual($"T Th", Course.Schedule);
        }

        [TestMethod]
        public void SetSchedule_ValidData_ScheduleValueChanged()
        {
            Course.Schedule = "TEST_VALUE";
            Assert.AreEqual($"TEST_VALUE", Course.Schedule);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetSchedule_InvalidData_ScheduleValueChanged()
        {
            Course.Schedule = "";
            Assert.Fail();
        }

        [TestMethod]
        public void GetCredits_ReturnsDurationTimesDaysPerWeek()
        {
            Assert.AreEqual(5, Course.Credits);
        }

        [TestMethod]
        public void GetCoursesCreated_ReturnsValue()
        {
            int start = Assignment4.UniversityCourse.CoursesCreated;
            Assignment4.UniversityCourse course2 = new Assignment4.UniversityCourse(
                ".Net GUI", "CEB 207", new DateTime(2018, 10, 14, 2, 0, 0), new DateTime(2018, 10, 14, 4, 30, 0),
                "CSCD", "371", "Michaelis", "T Th");

            Assert.AreEqual(start + 1, Assignment4.UniversityCourse.CoursesCreated);
        }

        [TestMethod]
        public void GetSummaryInfo_ReturnsSummary()
        {
            Assert.AreEqual(
                $"Title: {Course.Title}\n" +
                $"Location: {Course.Location}\n" +
                $"Dates: {Course.StartDate}-{Course.EndDate}" +
                $"Instructor: {Course.Instructor}\n" +
                $"Schedule: {Course.Schedule}",
            Course.GetSummaryInformation());

        }

    }
}
