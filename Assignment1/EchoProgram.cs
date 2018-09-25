using System;

namespace Assignment1
{
    class EchoProgram
    {
        static void Main(string[] args)
        {
            String userPhrase;

            Console.Write("Enter a phrase for the console to echo back: ");
            userPhrase = Console.ReadLine();
            Console.WriteLine($"Echo: {userPhrase}");
        }
    }
}
