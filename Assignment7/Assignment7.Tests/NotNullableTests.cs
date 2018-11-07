using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment7.Tests
{
    [TestClass]
    public class NotNullableTests
    {
        [TestMethod]
        public void PassInstatiatedValue_NotNullableInitialized()
        {
            string input = "I am not Null, I'm a real string!";
            NotNullable<string> sut = new NotNullable<string>(input);
            Assert.IsNotNull(sut.Value);
            Assert.AreEqual(input, sut.Value);
        }


        //Ideally we could specify T as not null and the compiler 
        //would mark the following code as error
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullValue_ExceptionThrown()
        {
            NotNullable<string> sut = new NotNullable<string>(null);
            Assert.Fail();
        }

    }
}
