using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System;
using System.Collections.Generic;

namespace CountingSort_Tests
{
    [TestClass]
    public class CountingSort_Tests
    {
        private const int zeroValue = 0;

        #region RepopulateArray
        private void RepopulateArray(Dictionary<int, int> possibleValues, int[] expected, int[] inputAndActualArray)
        {
            new CountingSort().RepopulateArray(possibleValues, inputAndActualArray);

            CollectionAssert.AreEqual(expected, inputAndActualArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepopulateArray_NullPossibleValues_exception()
        {
            Dictionary<int, int> possibleValues = null;
            int[] array = null;

            RepopulateArray(possibleValues, null, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepopulateArray_NullArray_exception()
        {
            var possibleValues = new Dictionary<int, int>();
            int[] array = null;

            RepopulateArray(possibleValues, null, array);
        }

        [TestMethod]
        public void RepopulateArray_FilledDictionary_ok()
        {
            var possibleValues = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 3 }
            };

            var inputAndActualArray = new int[] { 1, 2, 3, 2, 3, 3 };

            var expected = new int[] { 1, 2, 2, 3, 3, 3 };

            RepopulateArray(possibleValues, expected, inputAndActualArray);
        }
        #endregion

        #region ResetValuesToZero
        private void ResetValuesToZero(Dictionary<int, int> expected, Dictionary<int, int> inputAndActual)
        {
            new CountingSort().ResetValuesToZero(inputAndActual);

            CollectionAssert.AreEqual(expected, inputAndActual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResetValuesToZero_NullPossibleValues_exception()
        {
            Dictionary<int, int> inputAndActual = null;

            ResetValuesToZero(null, inputAndActual);
        }

        [TestMethod]
        public void ResetValuesToZero_EmptyDictionary_ok()
        {
            var inputAndActual = new Dictionary<int, int>();
            var expected = new Dictionary<int, int>();

            ResetValuesToZero(expected, inputAndActual);
        }

        [TestMethod]
        public void ResetValuesToZero_FilledDictionary_ok()
        {
            var inputAndActual = new Dictionary<int, int>();
            var expected = new Dictionary<int, int>();
            var random = new Random();
            int number;

            for (int i = 1; i < 10; i++)
            {
                number = random.Next(int.MinValue, int.MaxValue);
                inputAndActual.Add(number, i);
                expected.Add(number, zeroValue);
            }

            ResetValuesToZero(expected, inputAndActual);
        }
        #endregion

        #region GetPossibleValues
        private void GetPossibleValues(Dictionary<int, int> expected, int[] array)
        {
            var actual = new CountingSort().GetPossibleValues(array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPossibleValues_NullArray_exception()
        {
            int[] array = null;
            GetPossibleValues(null, array);
        }

        [TestMethod]
        public void GetPossibleValues_EmptyArray()
        {
            var expected = new Dictionary<int, int>();

            var array = new int[] { };
            GetPossibleValues(expected, array);
        }

        [TestMethod]
        public void GetPossibleValues_ok()
        {
            var expected = new Dictionary<int, int>
            {
                { -30, zeroValue },
                { -20, zeroValue },
                { 0, zeroValue },
                { 10, zeroValue },
                { 20, zeroValue },
                { 30, zeroValue },
                { 90, zeroValue }
            };

            var array = new int[] { 10, 0, 10, 20, 30, 10, -20, -30, 90 };

            GetPossibleValues(expected, array);
        }
        #endregion

        #region Sort
        private void Sort(int[] expected, int[] array)
        {
            new CountingSort().Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_exception()
        {
            int[] expected = null;
            int[] array = null;

            Sort(expected, array);
        }

        [TestMethod]
        public void Sort_EmptyArray_ok()
        {
            var expected = new int[] { };

            var array = new int[] { };

            Sort(expected, array);
        }

        [TestMethod]
        public void Sort_InputArray_ok()
        {
            var array = new int[] { 9, -5, 5, 3, 7, -1, 6, 9, -1, 7, 2, 3, 6, 0, -7, 2, 7, -8, -9 };

            var expected = (int[])array.Clone();
            Array.Sort(expected);

            Sort(expected, array);
        }

        private void Sort(int[] expected, int[] array, Dictionary<int, int> possibleValues)
        {
            new CountingSort().Sort(possibleValues, array);

            CollectionAssert.AreEqual(expected, array);
        }

        #region Null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullPossibleValues_exception()
        {
            Dictionary<int, int> possibleValues = null;

            Sort(null, null, possibleValues);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray2_exception()
        {
            int[] array = null;
            var possibleValues = new Dictionary<int, int>();

            Sort(null, array, possibleValues);
        }
        #endregion

        #region Empty
        [TestMethod]
        public void Sort_EmptyArray2_ok()
        {
            var expected = new int[] { };
            var array = new int[] { };
            var possibleValues = new Dictionary<int, int>();

            Sort(expected, array, possibleValues);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sort_EmptyPossibleValues_exception()
        {
            var expected = new int[] { };
            var array = new int[] { 0, 1 };

            var possibleValues = new Dictionary<int, int>();

            Sort(expected, array, possibleValues);
        }
        #endregion

        [TestMethod]
        public void Sort_PossibleValuesAndInputArray_ok()
        {
            var array = new int[] { 9, -5, 5, 3, 7, -1, 6, 9, -1, 7, 2, 3, 6, 0, -7, 2, 7, -8, -9 };

            var expected = (int[])array.Clone();
            Array.Sort(expected);
            var possibleValues = new Dictionary<int, int> {
                { -9, zeroValue },
                { -8, zeroValue },
                { -7, zeroValue },
                { -5, zeroValue },
                { -1, zeroValue },
                { 0, zeroValue },
                { 2, zeroValue },
                { 3, zeroValue },
                { 5, zeroValue },
                { 6, zeroValue },
                { 7, zeroValue },
                { 9, zeroValue }
            };

            Sort(expected, array, possibleValues);
        }
        #endregion
    }
}