using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtList.Tests
{
    [TestClass]
    public class ArtListTests
    {
        [TestMethod]
        public void ArtList_Count()
        {
            const int expected = 0;
            var list = new ArtList<int>();

            var actual = list.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArtList_Add()
        {
            var expected = 0;
            var list = new ArtList<int>();

            var actual = list.Count;
            Assert.AreEqual(expected, actual);


            list.Add(1);
            expected = 1;
            actual = list.Count;
            Assert.AreEqual(expected, actual);

            list.Add(2);
            expected = 2;
            actual = list.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}