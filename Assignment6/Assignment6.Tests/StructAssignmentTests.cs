using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment6.Tests
{

    interface IAnimalRoyalty
    {
        void GentrifyName();
    }

    struct Dog : IAnimalRoyalty
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void GentrifyName()
        {
            Name = $"Sir {Name} the Earl of Windsor";
        }
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

        [TestMethod]
        public void PassStructByValue_ChangeValues_OriginalUnchanged()
        {
            ValueChanger.ChangeStructValue(_Dog);
            Assert.AreEqual(5, _Dog.Age);
            Assert.AreEqual("Rusty", _Dog.Name);
        }

        [TestMethod]
        public void PassClass_ChangeValues_OriginalChanged()
        {
            ValueChanger.ChangeClass(_Cat);
            Assert.AreEqual(12, _Cat.Age);
            Assert.AreEqual("Garfield", _Cat.Name);
        }

        [TestMethod]
        public void PassStructByReference_ChangeValues_OriginalChanged()
        {
            Dog d = new Dog {Name = "Baxter",Age = 99 };
            ValueChanger.ChangeStructRef(ref _Dog);
            Assert.AreEqual(42, _Dog.Age);
            Assert.AreEqual("Benji", _Dog.Name);
        }

        [TestMethod]
        public void PassClass_CreateNewObject_OriginalChanged()
        {
            ValueChanger.ChangeClassRef(ref _Cat);
            Assert.AreEqual(7, _Cat.Age);
            Assert.AreEqual("Whiskers", _Cat.Name);
            
        }

        public void PassStructByInterface_ChangeValues_OriginalChanged()
        {
            IAnimalRoyalty animal = _Dog;
            animal.GentrifyName();
            Assert.AreEqual(5, _Dog.Age);
            Assert.AreEqual("Sir Rusty the Earl of Windsor", _Dog.Name);
        }

    }

    static class ValueChanger
    {
        public static void ChangeStructValue(Dog dog)
        {
            dog.Age = 42;
            dog.Name = "Benji";
        }

        public static void ChangeStructRef(ref Dog dog)
        {
            dog.Age = 42;
            dog.Name = "Benji";
        }

        public static void ChangeClass(Cat cat)
        {
            cat.Name = "Garfield";
            cat.Age = 12;
        }

        public static void ChangeClassRef(ref Cat cat)
        {
            cat = new Cat("Whiskers", 7);
        }

    }

}
