using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.UnitTests
{
    [TestClass]
    public class OutputExitUnitTests
    {
        [TestMethod]
        public void TestExitProgram()
        {
            string userInput = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{userInput}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void TestExitCapsProgram()
        {
            string userInput = "EXIT";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{userInput}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void TestEmptyLine()
        {
            string line = "";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{line}
>>Enter math operation to solve (e.g. 2*5): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void TestAddPositives()
        {
            string line = "2+2";
            string answer = "4";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{line}
>>{answer}
>>Enter math operation to solve (e.g. 2*5): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }


    }



}
