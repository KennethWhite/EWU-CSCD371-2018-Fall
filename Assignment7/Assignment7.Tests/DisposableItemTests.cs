using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Assignment7.Tests
{
    [TestClass]
    public class DisposableItemTests
    {
        [TestMethod]
        public void CreateDisposableItem_ResourcesAvailableDecreases()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            DisposableItem item = new DisposableItem();
            Assert.AreEqual(resourcesBefore-1, DisposableItem.ResourcesAvailable);
        }


  
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateDisposableItem_NoResourcesAvailable_ExceptionThrown()
        {
            DisposableItem item = new DisposableItem();
            DisposableItem item2 = new DisposableItem();
            DisposableItem item3 = new DisposableItem(); //fails
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ManuallyDisposeItem_ResourceFreed()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            DisposableItem item = new DisposableItem();
            item.Dispose();
            Assert.AreEqual(resourcesBefore, DisposableItem.ResourcesAvailable);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ItemLeavesScope_ObjectFinalizeInvoked_ResourceFreed()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            if (true)
            {
                DisposableItem item = new DisposableItem();
            }
            Assert.AreEqual(resourcesBefore, DisposableItem.ResourcesAvailable);
        }

    }
}
