using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using static IDateTime.IDateTime;

namespace EventTimer
{
    public class TimeManager : INotifyPropertyChanged, IDateTime.IDateTime
    {
        private DateTime StartTime;
        private DateTime EndTime;
        private bool TimerRunning;
        private DispatcherTimer _ClockTimer;
        private DispatcherTimer _EventTimer;


        public TimeManager(Action<TimeEvent> StopEvent)
        {
            OnStopClicked += StopEvent;
            CurrentTime = GetDateTimeNow();
            _ClockTimer = new DispatcherTimer {
                Interval = TimeSpan.FromMilliseconds(100),
            };
            _ClockTimer.Tick += UpdateCurrentTime;
            _ClockTimer.Start();
        }

        public bool ClockTimerIsTicking() { return _ClockTimer.IsEnabled; }
        public bool EventTimerIsTicking() { return TimerRunning; }

        public DateTime CurrentTime{
            get => _CurrentTime;
            set
            {
                _CurrentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }
        private DateTime _CurrentTime;
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool StartTimer()
        {
            StartTime = TimerRunning ? StartTime : GetDateTimeNow();
            bool TimerStarted = !TimerRunning;
            if (TimerStarted)
            {
                TimerRunning = true;
                _EventTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(10)
                };
                _EventTimer.Tick += UpdateTimeElapsed;
                _EventTimer.Start();
                
            }
            return TimerStarted;
        }

        public bool EndTimer(string description)
        {
            if (TimerRunning)
            {
                _EventTimer.Stop();
                EndTime = GetDateTimeNow();
                TimerRunning = false;
                OnStopClicked(new TimeEvent {
                    Interval = EndTime - StartTime,
                    Description = description
                });
                return true;
            }
            return false;
        }

        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }

        private void UpdateTimeElapsed(object sender, EventArgs args)
        {
            TimeElapsed = DateTime.Now - StartTime;
        }
        private void UpdateCurrentTime(object sender, EventArgs args)
        {
            CurrentTime = DateTime.Now;
        }

        public Action<TimeEvent> OnStopClicked { get; set; }
        
        public struct TimeEvent
        {
            public TimeSpan Interval;
            public string Description { get; set; }
            public string IntervalString {
                get => $"{Interval.ToString("hh':'mm':'ss':'ff")}";
                }
        }

    }

}

