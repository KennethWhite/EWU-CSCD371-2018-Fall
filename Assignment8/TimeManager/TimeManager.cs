using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager
{
    public class TimeManager
    {
        public event Func<int> GetValue;
        public event Action TimeEventCreated;
        public event EventHandler<EventArgs> GenericEvent;
        public event EventHandler<AddEventArgs> AddEvent;

        public void RaiseEvent()
        {
            TimeEventCreated?.Invoke();
        }

        public int RaiseGetValue() => GetValue?.Invoke() ?? 0;

        public void RaiseGenericEvent(EventArgs e)
        {

        }

        public class AddEventArgs : EventArgs
        {

        }

    }
}
