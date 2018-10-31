using System;
using System.Collections.Generic;
using System.Text;
using Assignment4;

namespace Assignment5
{
    public class EventConsoleProgram
    {

        private static MyConsole MyConsole = new MyConsole();
        private static List<Event> Events = new List<Event>();

        public static void Main()
        {
            bool cont = true;
            do
            {
                PrintMenu();
                string line = GetInput();
                PerformMenuChoice(line);
                cont = ContinueProgram(line);
            } while (cont);
        }



        private static void PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("This is an Event Scheduler.");
            menu.AppendLine("Type q/quit to exit, otherwise the number of your selection." + Environment.NewLine);
            menu.AppendLine("1: Create a new event.");
            menu.AppendLine("2: Print list of all created events.");
            MyConsole.WriteLine(menu.ToString());
        }

        private static string GetInput()
        {
            return MyConsole.ReadLine();
        }

        public static bool ContinueProgram(string line)
        {
            string lower = line.ToLower();
            return !(lower.Equals("q")
                || lower.Equals("quit")
                || lower.Equals("exit"));
        }

        private static void PerformMenuChoice(string line)
        {
            switch (line)
            {
                case "1":
                    Events.Add(CreateEventFromInput());
                    break;
                case "2":
                    PrintList();
                    break;
                case "q":
                case "quit":
                case "exit":
                    MyConsole.WriteLine("Program will exit");
                    break;
                default:
                    MyConsole.WriteLine($"Invalid menu option: {line}");
                    break;
            }
        }

        private static void PrintList()
        {
            MyConsole.WriteLine("The current list of events is:" + Environment.NewLine);
            foreach (Event e in Events)
            {
                MyConsole.WriteLine(e.GetSummaryInformation() + Environment.NewLine);
            }
        }

        private static Event CreateEventFromInput()
        {
            string title;
            string location;
            DateTime startDate;
            DateTime endDate;
          
                do
                {
                    MyConsole.WriteLine("Please enter the Event Title (3 or more characters):");
                    title = MyConsole.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(title));
                do
                {
                    MyConsole.WriteLine("Please enter the Event Location:");
                    location = MyConsole.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(title));
                do
                {
                    MyConsole.WriteLine("Please enter the Event start date:");
                }
                while (!TryParseDateTime(out startDate));
                do
                {
                    MyConsole.WriteLine("Please enter the Event End date (must be after start date):");
                }
                while (!TryParseDateTime(out endDate));

                return new Event(title, location, startDate, endDate);
            

        }

        private static bool TryParseDateTime(out DateTime startDate)
        {
            bool validInput = true;
            try
            {
                MyConsole.WriteLine("Enter the year:");
                validInput &= int.TryParse(MyConsole.ReadLine(), out int year);
                MyConsole.WriteLine("Enter the month:");
                validInput &= int.TryParse(MyConsole.ReadLine(), out int month);
                MyConsole.WriteLine("Enter the day:");
                validInput &= int.TryParse(MyConsole.ReadLine(), out int day);
                MyConsole.WriteLine("Enter the hour:");
                validInput &= int.TryParse(MyConsole.ReadLine(), out int hour);
                MyConsole.WriteLine("Enter the minute:");
                validInput &= int.TryParse(MyConsole.ReadLine(), out int minute);
                int second = 0;
                startDate = new DateTime(year, month, day, hour, minute, second);
            }
            catch 
            {
                MyConsole.WriteLine("Problem creating date.");
                startDate = DateTime.Now;
                return false;
            }
            return validInput;
        }
    }
}
