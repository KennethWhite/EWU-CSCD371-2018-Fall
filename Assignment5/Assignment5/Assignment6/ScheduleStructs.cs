using System;

namespace Assignment6
{
    [Flags]
    public enum DaysOfWeek
    {
        Sunday = 1 << 0,
        Monday = 1 << 1,
        Tuesday = 1 << 2,
        Wednesday = 1 << 3,
        Thursday = 1 << 4,
        Friday = 1 << 5,
        Saturday = 1 << 6,
    }

    [Flags]
    public enum Quarter
    {
        Winter = 1 << 0,
        Spring = 1 << 1,
        Summer = 1 << 2,
        Fall = 1 << 3,
    }

    public readonly struct TimeValue
    {
        public int Hour { get; }
        public int Min { get; }
        public int Seconds { get; }
    }

    public readonly struct Schedule
    {
        public int DaysOfWeek { get; }
        public int Quarter { get; }
        public TimeValue StartTime { get; }
        public TimeSpan Duration { get; }
    }

}
