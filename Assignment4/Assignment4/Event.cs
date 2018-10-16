using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public class Event
    {

        public Event(string title, string location, DateTime start, DateTime end)
        {
            Title = title;
            Location = location;
            StartDate = start;
            EndDate = end;
            EventsCreated++;
        }

        public virtual string Title
        {
            get => _Title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"Course Title must be 3 or more characters: {value}");
                }
                _Title = value;
            }
        }
        private string _Title;

        public string Location { get; set; }

        public DateTime StartDate
        {
            get => _StartDate;
            private set
            {
                _StartDate = value;
            }
        }
        private DateTime _StartDate;

        public DateTime EndDate
        {
            get => _EndDate;
            private set
            {
                if (value.CompareTo(_StartDate) < 0)
                {
                    throw new ArgumentOutOfRangeException($"Event end date cannot be before start: {value.ToString()}");
                }
                _EndDate = value;
            }
        }
        private DateTime _EndDate;

        public static int EventsCreated
        {
            get;
            private set;
        }
        private static int _EventsCreated;

        public virtual string GetSummaryInformation()
        {
            return $@"Title: {Title}\n" +
                $"Location: {Location}\n" +
                $"Dates: {StartDate}-{EndDate}";

        }

    }
}
