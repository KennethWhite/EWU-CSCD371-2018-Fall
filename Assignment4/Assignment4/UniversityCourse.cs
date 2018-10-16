using System;

namespace Assignment4
{
    public class UniversityCourse : Event
    {


        public UniversityCourse(string title, string location, DateTime start,
            DateTime end,string dep, string id, string instructor, string daysOfWeek) :
            base(title, location, start, end)
        {
            Department = dep;
            CourseID = id;
            Instructor = instructor;
            Schedule = daysOfWeek;
            CoursesCreated++;
        }

        public void Deconstruct(out string title, out string location,
            out string instructor, out DateTime start, out DateTime end)
        {
            (title, location, instructor, start, end) =
                (Title, Location, Instructor, StartDate, EndDate);
        }

        public override string Title
        {
            get
            {
                return $"{Department} {CourseID}";
            }

        }

        public string Department
        {
            get => _Department;
            set
            {

                if (value.Length < 3)
                {
                    throw new ArgumentException($"Department code must be at least 3 characters {value}");
                }
                _Department = value;

            }
        }
        private string _Department;

        public string CourseID
        {
            get => _CourseID;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"CourseID number must be at least 3 characters {value}");
                }
                _CourseID = value;
            }

        }
        private string _CourseID;

        public string Instructor
        {
            get; set;
        }
        private string _Instructor;

        public string Schedule
        {
            get => _Schedule;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException($"Schedule must be at least 1 day per week: {value}");
                }
                _Schedule = value;
            }
        }
        private string _Schedule;

        public double Credits
        {
            get
            {
                string[] days = Schedule.Split(" ,");
                double hoursPerDay = EndDate.Hour - StartDate.Hour + (EndDate.Minute - StartDate.Minute) / 60.0;
                return days.Length * hoursPerDay;
            }
        }

        public static int CoursesCreated
        {
            get;
            private set;
        }
        private static int _CoursesCreated;

        public override string GetSummaryInformation()
        {
            return base.GetSummaryInformation() +
                $"Instructor: {Instructor}" +
                $"Schedule: {Schedule}";

        }



    }
}
