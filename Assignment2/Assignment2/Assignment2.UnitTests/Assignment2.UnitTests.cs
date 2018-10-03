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
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{line}
>>Enter math operation to solve (e.g. 2*5): ";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

    }



}
