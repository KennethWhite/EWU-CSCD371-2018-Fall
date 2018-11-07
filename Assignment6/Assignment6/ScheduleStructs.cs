using System;

namespace Assignment6
{
    public readonly struct TimeValue
    {

        public TimeValue(byte h, byte m, byte s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }

        public byte Hour { get; }
        public byte Minute { get; }
        public byte Second { get; }
    }

    public readonly struct Schedule
    {

        public Schedule(DaysOfWeek d, Quarter q, TimeValue tv, TimeSpan ts)
        {
            DaysOfWeek = d; //1
            Quarter = q;    //1
            StartTime = tv; //3
            Duration = ts;  //8
        }

        public DaysOfWeek DaysOfWeek { get; }
        public Quarter Quarter { get; }
        public TimeValue StartTime { get; }
        public TimeSpan Duration { get; }
    }

}
