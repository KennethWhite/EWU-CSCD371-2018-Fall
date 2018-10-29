using System;

namespace Assignment5
{
    public interface IEvent
    {
        string GetSummaryInformation();
        DateTime GetStartDate();
        DateTime GetEndDate();
    }
}
