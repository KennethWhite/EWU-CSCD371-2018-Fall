using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment6.Tests
{

    struct Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Cat
    {
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [TestClass]
    public class StructAssignmentTests
    {
        private Dog _Dog;
        private Cat _Cat;

        [TestInitialize]
        public void Setup()
        {
            _Dog = new Dog { Name = "Rusty", Age = 5 };
            _Cat = new Cat("Spots", 3);
        }


       
    }
}
