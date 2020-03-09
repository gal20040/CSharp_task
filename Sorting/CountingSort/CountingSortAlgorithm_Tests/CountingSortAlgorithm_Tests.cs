using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountingSortAlgorithm_Tests
{
    [TestClass]
    public class CountingSortAlgorithm_Tests
    {
        [TestMethod]
        public void Sort_emptyArray()
        {
            var expected = new int[] { };

            var inputArray = new int[] { };
            var actual = new CountingSortAlgorithm().Sort(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort()
        {
            var expected = new int[] { 0, 1, 1, 2, 2, 2, 3, 3, 3 };

            var inputArray = new int[] { };
            var actual = new CountingSortAlgorithm().Sort(inputArray);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}