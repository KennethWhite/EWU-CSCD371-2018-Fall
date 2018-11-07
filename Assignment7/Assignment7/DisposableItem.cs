using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    public class DisposableItem : IDisposable
    {
        public static int ResourcesAvailable { get; private set; } = 2;

        public DisposableItem()
        {
            if (!(ResourcesAvailable > 0))
            {
                throw new InvalidOperationException("No resources available on call to DisposableItem CTOR.");
            }
            ResourcesAvailable--;
        }

        public void Dispose()
        {
            ResourcesAvailable++;
        }

        //Override Object.Finalize()
        ~DisposableItem()
        {
            ResourcesAvailable--;
        }

    }
}
