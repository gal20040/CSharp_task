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
        public void Insert_mixedTree2_ok()
        {
            const string expected = "4 19 19 19 28 34 37 37 48 53 56 57 72 76 83 90 99";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(28);
            actualTree.Insert(19);
            actualTree.Insert(53);
            actualTree.Insert(57);
            actualTree.Insert(34);
            actualTree.Insert(83);
            actualTree.Insert(72);
            actualTree.Insert(19);
            actualTree.Insert(76);
            actualTree.Insert(99);
            actualTree.Insert(37);
            actualTree.Insert(48);
            actualTree.Insert(56);
            actualTree.Insert(90);
            actualTree.Insert(4);
            actualTree.Insert(19);
            actualTree.Insert(37);

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

        #region Find
        [TestMethod]
        public void Find_mixedTree_nullExpectedInLeftSubtree()
        {
            const int requiredNodeData = 10;

            var actualTree = new BinarySearchTree();

            actualTree.Insert(50);
            actualTree.Insert(40);
            actualTree.Insert(70);
            actualTree.Insert(45);

            var requiredNode = actualTree.Find(requiredNodeData);

            Assert.IsNull(requiredNode);
        }

        [TestMethod]
        public void Find_mixedTree_nullExpectedInRightSubtree()
        {
            const int requiredNodeData = 100;

            var actualTree = new BinarySearchTree();

            actualTree.Insert(50);
            actualTree.Insert(40);
            actualTree.Insert(70);
            actualTree.Insert(45);

            var requiredNode = actualTree.Find(requiredNodeData);

            Assert.IsNull(requiredNode);
        }

        [TestMethod]
        public void Find_mixedTree_ok()
        {
            const int expectedNodeData = 40;
            const int expectedRightChildData = 45;

            var actualTree = new BinarySearchTree();

            actualTree.Insert(50);
            actualTree.Insert(40);
            actualTree.Insert(70);
            actualTree.Insert(45);

            var requiredNode = actualTree.Find(expectedNodeData);
            var actualLeftChild = requiredNode.GetLeftChild() as TreeNode<int>;
            var actualRightChild = requiredNode.GetRightChild() as TreeNode<int>;

            Assert.AreEqual(requiredNode.Data, expectedNodeData);
            Assert.IsNull(actualLeftChild);
            Assert.AreEqual(actualRightChild.Data, expectedRightChildData);
        }

        [TestMethod]
        public void Find_leftDegeneratedTree_ok()
        {
            const int expectedNodeData = 20;
            const int expectedLeftChildData = 10;
            const int expectedRightChildData = 25;

            var actualTree = new BinarySearchTree();

            actualTree.Insert(40);
            actualTree.Insert(30);
            actualTree.Insert(20);
            actualTree.Insert(10);
            actualTree.Insert(25);

            var requiredNode = actualTree.Find(expectedNodeData);
            var actualLeftChild = requiredNode.GetLeftChild() as TreeNode<int>;
            var actualRightChild = requiredNode.GetRightChild() as TreeNode<int>;

            Assert.AreEqual(requiredNode.Data, expectedNodeData);
            Assert.AreEqual(actualLeftChild.Data, expectedLeftChildData);
            Assert.AreEqual(actualRightChild.Data, expectedRightChildData);
        }

        [TestMethod]
        public void Find_rightDegeneratedTree_ok()
        {
            const int expectedNodeData = 60;
            const int expectedRightChildData = 60;

            var actualTree = new BinarySearchTree();

            actualTree.Insert(60);
            actualTree.Insert(60);
            actualTree.Insert(70);
            actualTree.Insert(80);
            actualTree.Insert(90);

            var requiredNode = actualTree.Find(expectedNodeData);
            var actualLeftChild = requiredNode.GetLeftChild() as TreeNode<int>;
            var actualRightChild = requiredNode.GetRightChild() as TreeNode<int>;

            Assert.AreEqual(requiredNode.Data, expectedNodeData);
            Assert.IsNull(actualLeftChild);
            Assert.AreEqual(actualRightChild.Data, expectedRightChildData);
        }
        #endregion
    }
}