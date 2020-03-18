using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CountingSort_Tests
{
    [TestClass]
    public class CountingSort_Tests
    {
        #region PrepareNumbers
        [TestMethod]
        public void PrepareNumbers()
        {
            const int initialCount = 0;

            var expected = new Dictionary<int, int>
            {
                { -2, initialCount },
                { -1, initialCount },
                {  0, initialCount },
                {  1, initialCount },
                {  2, initialCount },
                {  3, initialCount }
            };

            var inputArray = new int[] { -2, -1, 0, 1, 2, 3 };
            var actual = new CountingSort().PrepareNumbers(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PrepareNumbers_repeatedNumber_exception()
        {
            var inputArray = new int[] { -2, -2, 0, 1, 2, 3 };
            new CountingSort().PrepareNumbers(inputArray);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PrepareNumbers_lesserNumber_exception()
        {
            var inputArray = new int[] { -2, -3, 0, 1, 2, 3 };
            new CountingSort().PrepareNumbers(inputArray);
        }

        [TestMethod]
        public void PrepareNumbers_emptyArray()
        {
            var expected = new Dictionary<int, int>();

            var inputArray = new int[] { };
            var actual = new CountingSort().PrepareNumbers(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region Sort
        [TestMethod]
        public void Sort_emptyArray()
        {
            var expected = new int[] { };

            var possibleValues = new int[] { };
            var inputArray = new int[] { };
            var actual = new CountingSort().Sort(possibleValues, inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_10123102_ok()
        {
            var expected = new int[] { 0, 0, 1, 1, 1, 2, 2, 3 };

            var possibleValues = new int[] { 0, 1, 2, 3 };
            var inputArray = new int[] { 1, 0, 1, 2, 3, 1, 0, 2 };
            var actual = new CountingSort().Sort(possibleValues, inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_101231minus2minus39_ok()
        {
            var expected = new int[] { -3, -2, 0, 1, 1, 1, 2, 3, 9 };

            var possibleValues = new int[] { -3, -2, 0, 1, 2, 3, 9 };
            var inputArray = new int[] { 1, 0, 1, 2, 3, 1, -2, -3, 9 };
            var actual = new CountingSort().Sort(possibleValues, inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
    }
}