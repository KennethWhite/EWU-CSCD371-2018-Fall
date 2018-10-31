using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class MyConsole : IConsole
    {

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
