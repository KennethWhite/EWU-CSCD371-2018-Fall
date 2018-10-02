using System;
using System.Text.RegularExpressions;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'exit' to end program.");
            bool runFlag = true;
            while (runFlag) {
                Console.Write("Enter math operation to solve (e.g. 2*5): ");
                String line = Console.ReadLine();
                runFlag = line.ToLower().Equals("exit") ? false : true;
                if (runFlag)
                    evaluateLine(line);

                    
            }
            Console.WriteLine("Program complete.");
        }

        static bool runCheck(out string line)
        {
            line = Console.ReadLine();
            return line.ToLower().Equals("exit") ? false : true;
        }

        static MatchCollection parseOneLine(string line)
        {
            char[] delimiters = { '+', '-', '/', '*', '%', '^',  };
            line = System.Text.RegularExpressions.Regex.Replace(line, " ", "");
            Regex regex = new Regex("(-?\\d+)(.\\d+)?"); //0-1 minus signs followed by 1+ digits, optional decimal point and precision digits
            MatchCollection matches = regex.Matches(line);

            if (matches.Count != 2)
                throw new ArgumentException($"Invalid expression {line}");
            return matches;
        }

    }
}
