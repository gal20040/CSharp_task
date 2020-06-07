using DataStructures.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests.BinaryTree
{
    [TestClass]
    public class TreeNode_Tests : BaseTest
    {
        private TreeNode<int> getTreeWithNodes(int nodeCount)
        {
            if (nodeCount <= 0) return null;

            var treeNodeData = new Random().Next();
            nodeCount--;
            var nodesInRightSubtree = nodeCount / 2;
            var nodesInLeftSubtree = nodeCount - nodesInRightSubtree;

            var treeNode = new TreeNode<int>(treeNodeData, getTreeWithNodes(nodesInLeftSubtree), getTreeWithNodes(nodesInRightSubtree));

            return treeNode;
        }

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
        public void CountLeaves_onlyRoot_1LeafExpected()
        {
            var nodeCount = 1;
            var expectedCountLeaves = 1;

            var treeNode = getTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves);
        }

        [TestMethod]
        public void CountLeaves_RootAndSeveralLevelsOfNodes_SeveralLeafExpected()
        {
            const int maxDepth = 10;
            var treeDepth = 1 + new Random().Next(maxDepth);
            var nodeCount = 0;
            for (int i = 0; i <= treeDepth; i++)
            {
                nodeCount += (int)Math.Pow(2, i);
            }
            var expectedCountLeaves = (int)Math.Pow(2, treeDepth);

            var treeNode = getTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves, $"\ntreeDepth = {treeDepth}, nodeCount = {nodeCount}");
        }

        [TestMethod]
        public void CountLeaves_leftDegeneratedTree_1LeafExpected()
        {
            var expectedCountLeaves = 1;

            var nodeCount = 5;
            var treeNode = getLeftDegeneratedTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves);
        }

        private TreeNode<int> getLeftDegeneratedTreeWithNodes(int nodeCount)
        {
            TreeNode<int> treeNode = null;

            while (nodeCount > 0)
            {
                var treeNodeData = new Random().Next();

                treeNode = new TreeNode<int>(treeNodeData, treeNode);

                nodeCount--;
            }

            return treeNode;
        }

        private TreeNode<int> getRightDegeneratedTreeWithNodes(int nodeCount)
        {
            TreeNode<int> treeNode = null;

            while (nodeCount > 0)
            {
                var treeNodeData = new Random().Next();

                treeNode = new TreeNode<int>(treeNodeData, null, treeNode);

                nodeCount--;
            }

            return treeNode;
        }
        #endregion

        #region Depth
        [TestMethod]
        public void Depth_onlyRoot_0Expected()
        {
            var expectedDepth = 0;

            var nodeCount = 1;
            var treeNode = getLeftDegeneratedTreeWithNodes(nodeCount);

            var actualDepth = treeNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        [TestMethod]
        public void Depth_leftDegeneratedTree_7LeafExpected()
        {
            var expectedDepth = 7;

            var nodeCount = expectedDepth + 1;
            var treeNode = getLeftDegeneratedTreeWithNodes(nodeCount);

            var actualDepth = treeNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        [TestMethod]
        public void Depth_leftAndRightDegeneratedTree_7LeafExpected()
        {
            var leftTreeNodeCount = 6;
            var rightTreeNodeCount = leftTreeNodeCount + 1;
            var expectedDepth = rightTreeNodeCount;

            var leftSubtreeNode = getLeftDegeneratedTreeWithNodes(leftTreeNodeCount);
            var rightSubtreeNode = getRightDegeneratedTreeWithNodes(rightTreeNodeCount);
            var rootNode = new TreeNode<int>(1, leftSubtreeNode, rightSubtreeNode);

            var actualDepth = rootNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }
        #endregion

        #region 
        #endregion

        #region 
        #endregion
    }
}