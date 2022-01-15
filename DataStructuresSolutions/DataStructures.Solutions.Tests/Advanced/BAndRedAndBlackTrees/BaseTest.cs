namespace DataStructures.Solutions.Tests.Advanced.BAndRedAndBlackTrees
{
    using DataStructures.Solutions.Advanced.BAndRedAndBlackTrees;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTest
    {
        public IHierarchy<int> Hierarchy { get; private set; }

        public const int DefaultRootValue = 5;

        [TestInitialize]
        public void Initialize()
        {
            Hierarchy = new Hierarchy<int>(5);
        }
    }
}
