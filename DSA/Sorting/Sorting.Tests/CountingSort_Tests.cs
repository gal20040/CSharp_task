using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System;
using System.Collections.Generic;

namespace CountingSort_Tests
{
    [TestClass]
    public class CountingSort_Tests
    {
        #region GetPossibleValues
        [TestMethod]
        public void GetPossibleValues_ok()
        {
            const int zero = 0;
            var expected = new Dictionary<int, int>
            {
                { -30, zero },
                { -20, zero },
                { 0, zero },
                { 10, zero },
                { 20, zero },
                { 30, zero },
                { 90, zero }
            };
            
            var inputArray = new int[] { 10, 0, 10, 20, 30, 10, -20, -30, 90 };
            var actual = new CountingSort().GetPossibleValues(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPossibleValues_EmptyArray()
        {
            var expected = new Dictionary<int, int>();

            var inputArray = new int[] { };
            var actual = new CountingSort().GetPossibleValues(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region Sort
        //[TestMethod]
        ////todo: with exception
        //public void Sort_()
        //{
        //}

        [TestMethod]
        public void Sort_PossibleValuesAndEmptyArray_ok()
        {
            var expected = new int[] { };

            var possibleValues = new int[] { };
            var inputArray = new int[] { };
            var actual = new CountingSort().Sort(possibleValues, inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_JustEmptyArray_ok()
        {
            var expected = new int[] { };

            var inputArray = new int[] { };
            var actual = new CountingSort().Sort(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_JustInputArray_ok()
        {
            var inputArray = new int[] { 9, -5, 5, 3, 7, -1, 6, 9, -1, 7, 2, 3, 6, 0, -7, 2, 7, -8, -9 };

            var expected = (int[])inputArray.Clone();
            Array.Sort(expected);

            var actual = new CountingSort().Sort(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_PossibleValuesAndInputArray_ok()
        {
            var inputArray = new int[] { 1, 0, 1, 2, 3, 1, -2, -3, 9 };

            var expected = (int[])inputArray.Clone();
            Array.Sort(expected);

            var possibleValues = new int[] { -3, -2, 0, 1, 2, 3, 9 };
            var actual = new CountingSort().Sort(possibleValues, inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
    }
}