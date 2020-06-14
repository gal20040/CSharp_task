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
        public void Insert_mixedTree_ok()
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

        [TestMethod]
        public void Insert_leftDegeneratedTree_ok()
        {
            const string expected = "10 20 30 40";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(40);
            actualTree.Insert(30);
            actualTree.Insert(20);
            actualTree.Insert(10);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_rightDegeneratedTree_ok()
        {
            const string expected = "60 70 80 90";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(60);
            actualTree.Insert(70);
            actualTree.Insert(80);
            actualTree.Insert(90);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_treeWithIdenticalNodes_ok()
        {
            const string expected = "60 60 60 60";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(60);
            actualTree.Insert(60);
            actualTree.Insert(60);
            actualTree.Insert(60);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_leftAndRightDegeneratedTree_ok()
        {
            const string expected = "10 20 30 40 50 60 70 80 90";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(50);

            actualTree.Insert(40);
            actualTree.Insert(30);
            actualTree.Insert(20);
            actualTree.Insert(10);

            actualTree.Insert(60);
            actualTree.Insert(70);
            actualTree.Insert(80);
            actualTree.Insert(90);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}