using ArtList.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ArtList.Tests
{
    [TestClass]
    public class ArtListTests
    {
        [TestMethod]
        public void ArtList_EmptyArtListCount()
        {
            var artList = new ArtList<int>();
            var list = new List<int>();

            var listsComparer = new ListsComparer();
            var isEqual = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(isEqual, comparisonResult);
        }

        [TestMethod]
        public void ArtList_Add100ItemsToArtListAndCount()
        {
            var artList = new ArtList<int>();
            var list = new List<int>();

            var listsComparer = new ListsComparer();
            var result = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            for (int i = 0; i < 100; i++)
            {
                artList.Add(i);
                list.Add(i);
                result = listsComparer.IsEqual(list, artList, out comparisonResult);
                Assert.IsTrue(result, comparisonResult);
            }

            var j = 10;
            artList[j] += j;
            list[j] += j;
            result = listsComparer.IsEqual(list, artList, out comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            j = 20;
            artList[j] += j;
            list[j] += j;
            result = listsComparer.IsEqual(list, artList, out comparisonResult);
            Assert.IsTrue(result, comparisonResult);
        }
    }
}