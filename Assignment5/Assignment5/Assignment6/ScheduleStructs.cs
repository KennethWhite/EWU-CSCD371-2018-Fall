using System;

namespace Assignment6
{
    public readonly struct TimeValue
    {

        public TimeValue(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }

        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }
    }

    public readonly struct Schedule
    {

        public Schedule(DaysOfWeek d, Quarter q, TimeValue tv, TimeSpan ts)
        {
            DaysOfWeek = d;
            Quarter = q;
            StartTime = tv;
            Duration = ts;
        }

        public Enum DaysOfWeek { get; }
        public Enum Quarter { get; }
        public TimeValue StartTime { get; }
        public TimeSpan Duration { get; }
    }

}
