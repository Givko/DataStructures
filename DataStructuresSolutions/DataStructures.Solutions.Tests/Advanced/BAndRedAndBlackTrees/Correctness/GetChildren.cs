using System.Linq;

namespace DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees.Correctness
{
    using System;
    using DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetChildren : BaseTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetChildren_WithNonExistantElement_ShouldThrowException()
        {
            Hierarchy.GetParent(-17);
        }

        [TestMethod]
        public void GetChildren_WithAnElementWithNoChildren_ShouldReturnEmptyCollection()
        {
            Hierarchy.Add(DefaultRootValue, 13);
            Hierarchy.Add(DefaultRootValue, 14);
            Hierarchy.Add(13, 17);
            Hierarchy.Add(13, -666);

            var result = Hierarchy.GetChildren(-666).ToArray();

            CollectionAssert.AreEqual(result, new int[0], "Incorrect amount of children returned!");
        }

        [TestMethod]
        public void GetChildren_WithAnElementWithOneChild_ShouldReturnACollectionWithOneElement()
        {
            Hierarchy.Add(DefaultRootValue, 55);
            Hierarchy.Add(DefaultRootValue, 10);
            Hierarchy.Add(55, 17);
            Hierarchy.Add(55, 18);
            Hierarchy.Add(10, -666);

            var result = Hierarchy.GetChildren(10).ToArray();

            CollectionAssert.AreEqual(result, new[] { -666 }, "Incorrect amount of children returned!");
        }

        [TestMethod]
        public void GetChildren_WithAnElementWithMultipleChildren_ShouldReturnACorrectCollection()
        {
            Hierarchy.Add(DefaultRootValue, 25);
            Hierarchy.Add(DefaultRootValue, 110);
            Hierarchy.Add(25, -10);
            Hierarchy.Add(110, 22);
            Hierarchy.Add(110, 333);
            Hierarchy.Add(110, 15);
            Hierarchy.Add(110, 99);
            Hierarchy.Add(99, 1);

            var result = Hierarchy.GetChildren(110).ToArray();

            CollectionAssert.AreEqual(result, new[] { 22, 333, 15, 99 }, "Incorrect amount of children returned!");
        }
    }
}
