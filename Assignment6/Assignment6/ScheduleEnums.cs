﻿using System;

namespace Assignment6
{
    [Flags]
    public enum DaysOfWeek : byte
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
    public enum Quarter :byte
    {
        Winter = 1 << 0,
        Spring = 1 << 1,
        Summer = 1 << 2,
        Fall = 1 << 3,
    }

}
