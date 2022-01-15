using System.Linq;

namespace DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees.Correctness
{
    using System;
    using DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Add : BaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WithDuplicateElement_ShouldThrowException()
        {
            Hierarchy.Add(DefaultRootValue, 2);
            Hierarchy.Add(DefaultRootValue, 3);
            Hierarchy.Add(3, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ToNonExistingElement_ShouldThrowException()
        {
            Hierarchy.Add(DefaultRootValue + 1, 2);
        }

        [TestMethod]
        public void Add_WithSingleElement_ShouldIncrementCountByOne()
        {
            Hierarchy.Add(DefaultRootValue, 2);
            Assert.AreEqual(2, Hierarchy.Count, "Count did not increase correctly!");
        }

        [TestMethod]
        public void Add_WithMultipleElements_ShouldIncrementCountCorrectly()
        {
            var elementsToAdd = new[] { 3, 2, 7 };

            Hierarchy.Add(DefaultRootValue, elementsToAdd[0]);
            Hierarchy.Add(DefaultRootValue, elementsToAdd[1]);
            Hierarchy.Add(elementsToAdd[1], elementsToAdd[2]);

            Assert.AreEqual(1 + elementsToAdd.Length, Hierarchy.Count, "Count did not increase correctly!");
        }

        [TestMethod]
        public void Add_WithSingleElement_ShouldAddCorrectElement()
        {
            Assert.IsFalse(Hierarchy.Contains(2));

            Hierarchy.Add(DefaultRootValue, 2);

            Assert.IsTrue(Hierarchy.Contains(2), "Element wasn't added!");
        }

        [TestMethod]
        public void Add_WithSingleElement_ShouldCorrectlySetElementsParent()
        {
            Hierarchy.Add(DefaultRootValue, 111);
            Hierarchy.Add(111, 222);

            Assert.AreEqual(111, Hierarchy.GetParent(222), "Element's parent wasn't correct!");
        }

        [TestMethod]
        public void Add_WithMultipleElements_ShouldAddElementAtCorrectPlace()
        {
            Hierarchy.Add(DefaultRootValue, 6);
            Hierarchy.Add(DefaultRootValue, 2);
            Hierarchy.Add(6, 13);
            Hierarchy.Add(2, 7);
            Hierarchy.Add(7, 22);

            Hierarchy.Add(7, 25);

            Assert.AreEqual(25, Hierarchy.GetChildren(7).ToList()[1], "Element wasn't added at correct place!");
        }

        [TestMethod]
        public void Add_WithAddAfterRemoving_ShouldAddCorrectly()
        {
            Hierarchy.Add(DefaultRootValue, 2);
            Hierarchy.Remove(2);
            Assert.AreEqual(1, Hierarchy.Count);

            Hierarchy.Add(DefaultRootValue, 2);

            Assert.AreEqual(2, Hierarchy.Count);
        }
    }
}
