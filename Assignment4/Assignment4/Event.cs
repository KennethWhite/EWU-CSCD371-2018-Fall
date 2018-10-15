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
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"Course Title must be 3 or more characters: {value}");
                }
                this.title = value;
            }
        }
        private string title;

        public string Location { get; set; }

        public DateTime StartDate
        {
            get => startDate;
            private set
            {
                this.startDate = value;
            }
        }
        private DateTime startDate;

        public DateTime EndDate
        {
            get => endDate;
            private set
            {
                if (value.CompareTo(startDate) < 0)
                {
                    throw new ArgumentOutOfRangeException($"Event end date cannot be before start: {value.ToString()}");
                }
                this.endDate = value;
            }
        }
        private DateTime endDate;

        public static int EventsCreated
        {
            get;
            private set;
        }
        private static int eventsCreated;

        public virtual string GetSummaryInformation()
        {
            return $@"Title: {Title}\n" +
                $"Location: {Location}\n" +
                $"Dates: {StartDate}-{EndDate}";

        }

    }
}
