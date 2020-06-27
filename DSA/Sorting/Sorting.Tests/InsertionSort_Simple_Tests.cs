using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorting.Tests
{
    [TestClass]
    public class InsertionSort_Simple_Tests
    {
        #region Sort
        private void Sort(int[] expected, int[] array)
        {
            new InsertionSort_Simple().Sort(ref array);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_exception()
        {
            int[] inputAndActual = null;

            Sort(null, inputAndActual);
        }

        [TestMethod]
        public void Sort_EmptyArray_ok()
        {
            var expected = new int[] { };

            var inputAndActual = new int[] { };

            Sort(expected, inputAndActual);
        }

        [TestMethod]
        public void Sort_InputArray_ok()
        {
            const int numbersCounter = 10;
            var inputAndActual = new int[numbersCounter];

            var random = new Random();

            for (int i = 0; i < numbersCounter; i++)
            {
                inputAndActual[i] = random.Next(int.MinValue, int.MaxValue);
            }

            var expected = (int[])inputAndActual.Clone();
            Array.Sort(expected);

            Sort(expected, inputAndActual);
        }
        #endregion
    }
}