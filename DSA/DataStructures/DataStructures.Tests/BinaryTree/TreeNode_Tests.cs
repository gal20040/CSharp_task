using DataStructures.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests.BinaryTree
{
    [TestClass]
    public class TreeNode_Tests : BaseTest
    {
        private readonly Random random = new Random();

        private TreeNode<int> GetTreeWithNodes(int nodeCount)
        {
            //test commit
            if (nodeCount <= 0) return null;

            var treeNodeData = random.Next();
            nodeCount--;
            var nodesInRightSubtree = nodeCount / 2;
            var nodesInLeftSubtree = nodeCount - nodesInRightSubtree;

            var treeNode = new TreeNode<int>(treeNodeData, GetTreeWithNodes(nodesInLeftSubtree), GetTreeWithNodes(nodesInRightSubtree));

            return treeNode;
        }

        #region ctors
        [TestMethod]
        public void CreateTreeNode()
        {
            var treeNodeData = random.Next();

            var treeNode = new TreeNode<int>(treeNodeData);

            Assert.AreEqual(treeNodeData, treeNode.Data);
            Assert.IsNull(treeNode.GetLeftChild());
            Assert.IsNull(treeNode.GetRightChild());

            treeNodeData = random.Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);
            Assert.IsNull(treeNode.GetLeftChild());
            Assert.IsNull(treeNode.GetRightChild());
        }

        [TestMethod]
        public void CreateTreeNode_with_leftChild()
        {
            var leftChildData = random.Next();
            var treeNodeData = random.Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild);

            Assert.AreEqual(treeNodeData, treeNode.Data);

            var leftChildActual = treeNode.GetLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            Assert.IsNull(treeNode.GetRightChild());

            treeNodeData = random.Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);

            leftChildActual = treeNode.GetLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            Assert.IsNull(treeNode.GetRightChild());
        }

        [TestMethod]
        public void CreateTreeNode_with_left_and_rightChild()
        {
            var leftChildData = random.Next();
            var rightChildData = random.Next();
            var treeNodeData = random.Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var rightChild = new TreeNode<int>(rightChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild, rightChild);

            Assert.AreEqual(treeNodeData, treeNode.Data);

            var leftChildActual = treeNode.GetLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            var rightChildActual = treeNode.GetRightChild();
            Assert.AreEqual(rightChild, rightChildActual);

            treeNodeData = random.Next();
            treeNode.Data = treeNodeData;

            Assert.AreEqual(treeNodeData, treeNode.Data);

            leftChildActual = treeNode.GetLeftChild();
            Assert.AreEqual(leftChild, leftChildActual);

            rightChildActual = treeNode.GetRightChild();
            Assert.AreEqual(rightChild, rightChildActual);
        }
        #endregion

        #region IsLeaf
        [TestMethod]
        public void IsLeaf_nodeWithNoLeaves()
        {
            var treeNodeData = random.Next();

            var treeNode = new TreeNode<int>(treeNodeData);

            Assert.IsTrue(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithLeftChild()
        {
            var leftChildData = random.Next();
            var treeNodeData = random.Next();

            var leftChild = new TreeNode<int>(leftChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild);

            Assert.IsFalse(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithRightChild()
        {
            var rightChildData = random.Next();
            var treeNodeData = random.Next();

            TreeNode<int> leftChild = null;
            var rightChild = new TreeNode<int>(rightChildData);
            var treeNode = new TreeNode<int>(treeNodeData, leftChild, rightChild);

            Assert.IsFalse(treeNode.IsLeaf());
        }

        [TestMethod]
        public void IsLeaf_nodeWithBothChilds()
        {
            var leftChildData = random.Next();
            var rightChildData = random.Next();
            var treeNodeData = random.Next();

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

            var treeNode = GetTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves);
        }

        [TestMethod]
        public void CountLeaves_RootAndSeveralLevelsOfNodes_SeveralLeafExpected()
        {
            const int maxDepth = 10;
            var treeDepth = 1 + random.Next(maxDepth);
            var nodeCount = 0;
            for (int i = 0; i <= treeDepth; i++)
            {
                nodeCount += (int)Math.Pow(2, i);
            }
            var expectedCountLeaves = (int)Math.Pow(2, treeDepth);

            var treeNode = GetTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves, $"\ntreeDepth = {treeDepth}, nodeCount = {nodeCount}");
        }

        [TestMethod]
        public void CountLeaves_leftDegeneratedTree_1LeafExpected()
        {
            var expectedCountLeaves = 1;

            var nodeCount = 5;
            var treeNode = GetLeftDegeneratedTreeWithNodes(nodeCount);

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves);
        }

        [TestMethod]
        public void CountLeaves_preparedTree_3LeafExpected()
        {
            var expectedCountLeaves = 3;

            var treeNode = GetPreparedTree();

            var actualCountLeaves = treeNode.CountLeaves();

            Assert.AreEqual(expectedCountLeaves, actualCountLeaves);
        }

        private TreeNode<int> GetLeftDegeneratedTreeWithNodes(int nodeCount)
        {
            TreeNode<int> treeNode = null;

            while (nodeCount > 0)
            {
                var treeNodeData = random.Next();

                treeNode = new TreeNode<int>(treeNodeData, treeNode);

                nodeCount--;
            }

            return treeNode;
        }

        private TreeNode<int> GetRightDegeneratedTreeWithNodes(int nodeCount)
        {
            TreeNode<int> treeNode = null;

            while (nodeCount > 0)
            {
                var treeNodeData = random.Next();

                treeNode = new TreeNode<int>(treeNodeData, null, treeNode);

                nodeCount--;
            }

            return treeNode;
        }

        private TreeNode<int> GetLeftAndRightDegeneratedTreeWithNodes(int leftNodeCount, int rightNodeCount)
        {
            var leftTree = GetLeftDegeneratedTreeWithNodes(leftNodeCount);
            var rightTree = GetRightDegeneratedTreeWithNodes(rightNodeCount);

            var treeNodeData = random.Next();
            var root = new TreeNode<int>(treeNodeData, leftTree, rightTree);

            return root;
        }
        #endregion

        #region Depth
        [TestMethod]
        public void Depth_onlyRoot_0Expected()
        {
            var expectedDepth = 0;

            var nodeCount = 1;
            var treeNode = GetLeftDegeneratedTreeWithNodes(nodeCount);

            var actualDepth = treeNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        [TestMethod]
        public void Depth_leftDegeneratedTree_7LeafExpected()
        {
            var expectedDepth = 7;

            var nodeCount = expectedDepth + 1;
            var treeNode = GetLeftDegeneratedTreeWithNodes(nodeCount);

            var actualDepth = treeNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        [TestMethod]
        public void Depth_leftAndRightDegeneratedTree_7LeafExpected()
        {
            var leftTreeNodeCount = 6;
            var rightTreeNodeCount = leftTreeNodeCount + 1;
            var expectedDepth = rightTreeNodeCount;

            var rootNode = GetLeftAndRightDegeneratedTreeWithNodes(leftTreeNodeCount, rightTreeNodeCount);

            var actualDepth = rootNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        [TestMethod]
        public void Depth_preparedTree_3LeafExpected()
        {
            var rootNode = GetPreparedTree();

            var expectedDepth = 3;

            var actualDepth = rootNode.Depth();

            Assert.AreEqual(expectedDepth, actualDepth);
        }

        /// <summary>Возвращает подготовленное дерево.<br/>
        ///                       1
        ///                      / \
        ///                     /   \
        ///                    2     3
        ///                   / \   /
        ///                  4   5 6
        ///                         \
        ///                          7
        /// </summary>
        private TreeNode<int> GetPreparedTree()
        {
            var node4 = new TreeNode<int>(4);
            var node5 = new TreeNode<int>(5);
            var node7 = new TreeNode<int>(7);

            var node2 = new TreeNode<int>(2, node4, node5);

            var node6 = new TreeNode<int>(6, null, node7);

            var node3 = new TreeNode<int>(3, node6);

            var rootNode = new TreeNode<int>(1, node2, node3);

            return rootNode;
        }
        #endregion

        #region CopyTree
        [TestMethod]
        public void CopyTree_PreparedTree()
        {
            var expectedTree = GetPreparedTree();

            var actualTree = expectedTree.CopyTree();

            Assert.AreEqual(expectedTree.ToString(), actualTree.ToString());
        }

        [TestMethod]
        public void CopyTree_LeftDegeneratedTree()
        {
            var expectedTree = GetLeftDegeneratedTreeWithNodes(5);

            var actualTree = expectedTree.CopyTree();

            Assert.AreEqual(expectedTree.ToString(), actualTree.ToString());
        }

        [TestMethod]
        public void CopyTree_RightDegeneratedTree()
        {
            var expectedTree = GetRightDegeneratedTreeWithNodes(5);

            var actualTree = expectedTree.CopyTree();

            Assert.AreEqual(expectedTree.ToString(), actualTree.ToString());
        }

        [TestMethod]
        public void CopyTree_leftAndRightDegeneratedTree()
        {
            var leftTreeNodeCount = 6;
            var rightTreeNodeCount = leftTreeNodeCount + 1;
            var expectedTree = GetLeftAndRightDegeneratedTreeWithNodes(leftTreeNodeCount, rightTreeNodeCount);

            var actualTree = expectedTree.CopyTree();

            Assert.AreEqual(expectedTree.ToString(), actualTree.ToString());
        }
        #endregion

        #region ToString
        [TestMethod]
        public void ToString_PreparedTree()
        {
            var expectedTree = GetPreparedTree();
            var expectedTreeString = "4 2 5 1 6 7 3";

            var actualTree = expectedTree;
            var actualTreeString = actualTree.ToString();

            Assert.AreEqual(expectedTreeString, actualTreeString);
        }
        #endregion

        #region add child
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddLeftChild_nullAdded_ArgumentNullException()
        {
            var treeNode = new TreeNode<int>(1);

            treeNode.AddLeftChild(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRightChild_nullAdded_ArgumentNullException()
        {
            var treeNode = new TreeNode<int>(1);

            treeNode.AddRightChild(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLeftChild_leftChildAlreadyPresented_ArgumentException()
        {
            var leftChild = new TreeNode<int>(1);
            var treeNode = new TreeNode<int>(1, leftChild);

            treeNode.AddLeftChild(leftChild);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRightChild_rightChildAlreadyPresented_ArgumentException()
        {
            var rightChild = new TreeNode<int>(1);
            var treeNode = new TreeNode<int>(1, null, rightChild);

            treeNode.AddRightChild(rightChild);
        }

        [TestMethod]
        public void AddLeftChild_leftChildAdded_ok()
        {
            const string expected = "1 2";
            var treeNode = new TreeNode<int>(2);
            var leftChild = new TreeNode<int>(1);

            treeNode.AddLeftChild(leftChild);

            var actual = treeNode.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRightChild_rightChildAdded_ok()
        {
            const string expected = "2 3";
            var treeNode = new TreeNode<int>(2);
            var rightChild = new TreeNode<int>(3);

            treeNode.AddRightChild(rightChild);

            var actual = treeNode.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRightChild_sameValueAsRightChildAdded_ok()
        {
            const string expected = "2 2";
            var treeNode = new TreeNode<int>(2);
            var rightChild = new TreeNode<int>(2);

            treeNode.AddRightChild(rightChild);

            var actual = treeNode.ToString();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        #region 
        #endregion
    }
}