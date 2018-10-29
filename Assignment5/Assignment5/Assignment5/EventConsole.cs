using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class EventConsole : IConsole
    {

        public string EventReadLine()
        {
            return Console.ReadLine();
        }

        public void EventWriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
