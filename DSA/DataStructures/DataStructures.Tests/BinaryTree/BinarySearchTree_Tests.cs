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

        /// <summary>
        ///         ------28--------------------------------
        ///        /                                        \
        ///      19                              ------------53
        ///     /  \                            /              \
        ///    4    19                         34               57
        ///   /       \                          \             /  \
        ///  3         19                         37         56    83
        /// / \                                     \             /  \
        ///2   3                                     48      72--/    99
        ///                                         /          \      /
        ///                                       37            76   90
        /// </summary>
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

        #region Delete
        private BinarySearchTree GetBranchedTree(out string treeStructure)
        {
            var tree = new BinarySearchTree();

            tree.Insert(28);
            tree.Insert(19);
            tree.Insert(53);
            tree.Insert(57);
            tree.Insert(34);
            tree.Insert(83);
            tree.Insert(72);
            tree.Insert(19);
            tree.Insert(76);
            tree.Insert(99);
            tree.Insert(37);
            tree.Insert(48);
            tree.Insert(56);
            tree.Insert(90);
            tree.Insert(4);
            tree.Insert(19);
            tree.Insert(37);
            tree.Insert(3);
            tree.Insert(3);
            tree.Insert(2);

            treeStructure = "2 3 3 4 19 19 19 28 34 37 37 48 53 56 57 72 76 83 90 99";

            return tree;
        }

        [TestMethod]
        public void Delete_nonexistentValue_ok()
        {
            var actualTree = GetBranchedTree(out string expected);

            actualTree.Delete(1);

            var actual = actualTree.GetRoot().ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_rootAndTheOnlyNode_ok()
        {
            var actualTree = new BinarySearchTree();

            actualTree.Insert(4);

            actualTree.Delete(4);

            var root = actualTree.GetRoot();

            Assert.IsNull(root);
        }

        [TestMethod]
        public void Delete_Leaf_ok()
        {
            var actualTree = GetBranchedTree(out string expected);

            actualTree.Delete(2);
            expected = expected.Replace("2 3 ", " 3 ").Trim();
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(56);
            expected = expected.Replace(" 56 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(90);
            expected = expected.Replace(" 90 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(99);
            expected = expected.Replace(" 99", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_NodeWithOnlyLeftChild_ok()
        {
            var actualTree = GetBranchedTree(out string expected);

            actualTree.Delete(4);
            expected = expected.Replace(" 4 ", " ").Trim();
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(48);
            expected = expected.Replace(" 48 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(99);
            expected = expected.Replace(" 99", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_NodeWithOnlyRightChild_ok()
        {
            var actualTree = GetBranchedTree(out string expected);

            actualTree.Delete(37);
            expected = expected.Replace(" 37 ", " ").Trim();
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(34);
            expected = expected.Replace(" 34 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(72);
            expected = expected.Replace(" 72 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_RootWithOnlyLeftChild_ok()
        {
            //          28
            //         /
            //       19
            //      /
            //     4
            //    /
            //   3
            //  / \
            // 2   3
            var expected = "2 3 3 4 19 28";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(28);
            actualTree.Insert(19);
            actualTree.Insert(4);
            actualTree.Insert(3);
            actualTree.Insert(3);
            actualTree.Insert(2);

            actualTree.Delete(28);
            expected = expected.Replace(" 28", "");
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(19);
            expected = expected.Replace(" 19", "");
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(4);
            expected = expected.Replace(" 4", "");
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_RootWithOnlyRightChild_ok()
        {
            // 28
            //   \
            //    53
            //      \
            //       57
            //         \
            //          83
            //         /  \
            //    72--/    99
            //      \      /
            //       76   90
            var expected = "28 53 57 72 76 83 90 99";

            var actualTree = new BinarySearchTree();

            actualTree.Insert(28);
            actualTree.Insert(53);
            actualTree.Insert(57);
            actualTree.Insert(83);
            actualTree.Insert(72);
            actualTree.Insert(76);
            actualTree.Insert(99);
            actualTree.Insert(90);

            actualTree.Delete(28);
            expected = expected.Replace("28 ", "");
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(53);
            expected = expected.Replace("53 ", "");
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(57);
            expected = expected.Replace("57 ", "");
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_NodeWithBothChildren_ok()
        {
            var actualTree = GetBranchedTree(out string expected);

            actualTree.Delete(28);
            expected = expected.Replace(" 28 ", " ").Trim();
            var actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(53);
            expected = expected.Replace(" 53 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);

            actualTree.Delete(34);
            expected = expected.Replace(" 34 ", " ").Trim();
            actual = actualTree.GetRoot().ToString();
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}