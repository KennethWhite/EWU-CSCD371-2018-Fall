using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public static class EventLibrary
    {
        public static string Display(Object evnt)
        {
            switch (evnt)
            {
                case UniversityCourse course:
                    return course.GetSummaryInformation();
                case Event e when e.EndDate.CompareTo(DateTime.Now) > 0:
                    return e.GetSummaryInformation();
                case null:
                    throw new ArgumentNullException("Event null on call to Display!");
                default:
                    return evnt.ToString();
            }
        }

        public static string Display(List<Object> list)
        {
            string summary = "";
            foreach (Object o in list)
            {
                summary += Display(o);
            }
            return summary;
        }

    }
}
