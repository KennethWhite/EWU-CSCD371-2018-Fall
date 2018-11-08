using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    public class DisposableItem : IDisposable
    {
        public static int ResourcesAvailable { get; private set; } = 2;
        public bool Disposed { get; private set; }

        public DisposableItem()
        {
            if (!(ResourcesAvailable > 0))
            {
                throw new InvalidOperationException("No resources available on call to DisposableItem CTOR.");
            }
            ResourcesAvailable--;
            Disposed = false;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                ResourcesAvailable++;
                Disposed = true;
            }
        }

        //Override Object.Finalize()
        ~DisposableItem()
        {
            if (!Disposed) {
                ResourcesAvailable--;
                Disposed = true;
            } 
        }

    }
}
