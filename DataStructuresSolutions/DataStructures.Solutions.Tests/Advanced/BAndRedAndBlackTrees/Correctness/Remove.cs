namespace DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees.Correctness
{
    using System;
    using System.Linq;
    using DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Remove : BaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_WithNonExistantElement_ShouldThrowException()
        {
            var nonExistingElement = 7;
            Hierarchy.Remove(nonExistingElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_WithRootElement_ShouldThrowException()
        {
            Hierarchy.Remove(DefaultRootValue);
        }

        [TestMethod]
        public void Remove_WithOneElement_ShouldDecreaseCountByOne()
        {
            Hierarchy.Add(DefaultRootValue, 2);

            Hierarchy.Remove(2);

            Assert.AreEqual(1, Hierarchy.Count, "Count did not decrease correctly!");
        }

        [TestMethod]
        public void Remove_WithElementWithChildren_ShouldDecreaseCountCorrectly()
        {
            Hierarchy.Add(DefaultRootValue, 10);
            Hierarchy.Add(DefaultRootValue, 11);
            Hierarchy.Add(10, 12);
            Hierarchy.Add(10, 13);
            Hierarchy.Add(11, 14);
            Assert.AreEqual(6, Hierarchy.Count);

            Hierarchy.Remove(10);

            Assert.AreEqual(5, Hierarchy.Count, "Count did not decrease correctly!");
        }

        [TestMethod]
        public void Remove_WithElementWithNoChildren_ShouldRemoveElementCorrectly()
        {
            Hierarchy.Add(DefaultRootValue, 2);
            Hierarchy.Add(2, 3);

            Hierarchy.Remove(3);

            Assert.IsFalse(Hierarchy.Contains(3));
            Assert.IsFalse(Hierarchy.GetChildren(2).Contains(3));

        }

        [TestMethod]
        public void Remove_WithElementWithChildren_ShouldAttachChildrenToRemovedElementsParent()
        {
            Hierarchy.Add(DefaultRootValue, 10);
            Hierarchy.Add(DefaultRootValue, 11);
            Hierarchy.Add(10, 12);
            Hierarchy.Add(10, 13);
            Hierarchy.Add(11, 14);

            Hierarchy.Remove(10);

            Assert.AreEqual(DefaultRootValue, Hierarchy.GetParent(12));
            Assert.AreEqual(DefaultRootValue, Hierarchy.GetParent(13));

            var rootChildren = Hierarchy.GetChildren(DefaultRootValue).ToArray();
            CollectionAssert.AreEqual(
                rootChildren,
                new[] { 11, 12, 13 });
        }
    }
}
