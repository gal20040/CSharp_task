using DataStructures.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests.BinaryTree
{
    [TestClass]
    public class TreeNode_Tests : BaseTest
    {
        #region ctor
        [TestMethod]
        public void CreateTreeNode()
        {
            var treeNodeData = new Random().Next();

            var treeNode = new TreeNode<int>(treeNodeData);

            Assert.AreEqual(treeNodeData, treeNode.Data);
            Assert.IsNull(treeNode.getLeftChild());
            Assert.IsNull(treeNode.getRightChild());

            treeNodeData = new Random().Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);
            Assert.IsNull(treeNode.getLeftChild());
            Assert.IsNull(treeNode.getRightChild());
        }

        [TestMethod]
        public void CreateTreeNode_with_leftChild()
        {
            var leftChildData = new Random().Next();
            var treeNodeData = new Random().Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild);

            Assert.AreEqual(treeNodeData, treeNode.Data);

            var leftChildActual = treeNode.getLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            Assert.IsNull(treeNode.getRightChild());

            treeNodeData = new Random().Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);

            leftChildActual = treeNode.getLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            Assert.IsNull(treeNode.getRightChild());
        }

        [TestMethod]
        public void CreateTreeNode_with_left_and_rightChild()
        {
            var leftChildData = new Random().Next();
            var rightChildData = new Random().Next();
            var treeNodeData = new Random().Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var rightChild = new TreeNode<int>(rightChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild, rightChild);

            Assert.AreEqual(treeNodeData, treeNode.Data);

            var leftChildActual = treeNode.getLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            var rightChildActual = treeNode.getRightChild();
            Assert.AreEqual(rightChild, rightChildActual);

            treeNodeData = new Random().Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);

            leftChildActual = treeNode.getLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            rightChildActual = treeNode.getRightChild();
            Assert.AreEqual(rightChild, rightChildActual);
        }
        #endregion

        #region IsLeaf
        [TestMethod]
        public void IsLeaf_nodeWithNoLeaves()
        {
            var treeNodeData = new Random().Next();

            var treeNode = new TreeNode<int>(treeNodeData);

            Assert.IsTrue(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithLeftChild()
        {
            var leftChildData = new Random().Next();
            var treeNodeData = new Random().Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild);

            Assert.IsFalse(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithRightChild()
        {
            var rightChildData = new Random().Next();
            var treeNodeData = new Random().Next();

            TreeNode<int> leftChild = null;
            var rightChild = new TreeNode<int>(rightChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild, rightChild);

            Assert.IsFalse(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithBothChilds()
        {
            var leftChildData = new Random().Next();
            var rightChildData = new Random().Next();
            var treeNodeData = new Random().Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var rightChild = new TreeNode<int>(rightChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild, rightChild);

            Assert.IsFalse(treeNode.IsLeaf());
        }
        #endregion

        #region CountLeaves
        [TestMethod]
        public void CountLeaves()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        #region 
        #endregion
    }
}