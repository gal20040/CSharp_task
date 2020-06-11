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
            var tree = new BinarySearchTree<int>();

            tree.Insert(50);
            //tree.Insert(40);
            //tree.Insert(70);
            //tree.Insert(45);

            throw new System.NotImplementedException();
        }
        #endregion
    }
}