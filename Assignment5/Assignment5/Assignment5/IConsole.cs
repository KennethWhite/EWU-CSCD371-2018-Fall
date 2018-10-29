using System;

namespace Assignment5
{
    public interface IConsole
    {
        void EventWriteLine(string line);
        string EventReadLine();
    }
}
