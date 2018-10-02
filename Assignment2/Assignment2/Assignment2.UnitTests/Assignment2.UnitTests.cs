using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace Assignment2.UnitTests
{
    [TestClass]
    public class Assignment2UnitTests
    {
        [TestMethod]
        public void TestConsoleOutput()
        {
            string userInput = "";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{userInput}";
        }

        [TestMethod]
        public void TestExitProgram()
        {
            string userInput = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter math operation to solve (e.g. 2*5): <<{userInput}
>>Program complete.";
        }

    }
}
