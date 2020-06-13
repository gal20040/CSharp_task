using DataStructures.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests.BinaryTree
{
    [TestClass]
    public class BinarySearchTree_Tests : BaseTest
    {
        private readonly Random random = new Random();

        #region Insert
        [TestMethod]
        public void Insert_()
        {
            const string expected = "40 45 50 70";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(50);
            actualTree.Insert(40);
            actualTree.Insert(70);
            actualTree.Insert(45);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}