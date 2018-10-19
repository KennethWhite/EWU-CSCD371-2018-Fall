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
                case Event e:
                    return e.GetSummaryInformation();
                case null:
                    throw new ArgumentNullException("object null on call to Display");
                default:
                    return evnt.ToString();
            }
        }

        public static string Display<T>(List<T> list) where T : Event
        {
            string summary = "";
            foreach (T o in list)
            {
                summary += Display(o);
            }
            return summary;
        }

    }
}
