using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class BinaryTree_Tests : BaseTest
    {
        #region Add
        [TestMethod]
        public void Add_100Items()
        {
            const int maxValue = 50;
            const int capacity = 100;
            var random = new Random();

            var expected = new int[capacity];
            var actual = new BinaryTree<int>();
            int randNumber;

            for (int i = 0; i < capacity; i++)
            {
                randNumber = random.Next(maxValue);
                expected[i] = randNumber;
                actual.Add(randNumber);
            }

            Array.Sort(expected);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        #endregion
    }
}