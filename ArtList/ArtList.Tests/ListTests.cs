using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ArtList.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void List_Count()
        {
            const int expected = 0;
            var list = new List<int>();

            var actual = list.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void List_AddAndCount()
        {
            var expected = 0;
            var list = new List<int>();

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