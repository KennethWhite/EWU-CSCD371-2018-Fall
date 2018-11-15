using System;
using System.ComponentModel;
using static IDateTime.IDateTime;

namespace EventTimer
{
    public class TimeManager : INotifyPropertyChanged, IDateTime.IDateTime
    {
        private DateTime StartTime;
        private DateTime EndTime;
        private bool TimerRunning;

        public TimeSpan TimeElapsed
        {
            get => _TimeElapsed;
            set
            {
                if (_TimeElapsed != value)
                {
                    _TimeElapsed = value;
                    OnPropertyChanged(nameof(TimeElapsed));
                }
            }
        }
        private TimeSpan _TimeElapsed;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool StartTimer()
        {
            StartTime = TimerRunning ? StartTime : GetDateTimeNow();
            bool TimerStarted = !TimerRunning;
            TimerRunning = true;
            return TimerStarted;
        }

        public bool EndTimer()
        {
            if (TimerRunning)
            {
                EndTime = GetDateTimeNow();
                return true;
            }
            return false;
        }

        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }

        

    }
}
