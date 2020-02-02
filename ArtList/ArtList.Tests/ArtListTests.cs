using ArtList.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        #region Add
        [TestMethod]
        public void ArtList_Add100ItemsToArtListAndCount()
        {
            var artList = new ArtList<int>();
            var list = new List<int>();

            var listsComparer = new ListsComparer();
            bool result;
            string comparisonResult;

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

        [TestMethod]
        public void ArtList_Add100ItemsRemoveAtAndCount()
        {
            var artList = new ArtList<int>();
            var list = new List<int>();

            var listsComparer = new ListsComparer();
            bool result;
            string comparisonResult;

            for (int i = 0; i < 100; i++)
            {
                if (i > 0 && i % 10 == 0)
                {
                    artList.RemoveAt(i / 2);
                    list.RemoveAt(i / 2);
                }
                artList.Add(i);
                list.Add(i);
                result = listsComparer.IsEqual(list, artList, out comparisonResult);
                Assert.IsTrue(result, comparisonResult);
            }
        }
        #endregion

        #region RemoveAt
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_RemoveAtMinus1Index()
        {
            var artList = new ArtList<int>();

            for (int i = 0; i < 5; i++)
            {
                artList.Add(i);
            }

            artList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_RemoveAtMinus1Index()
        {
            var list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_RemoveAtCountIndex()
        {
            var artList = new ArtList<int>();

            for (int i = 0; i < 5; i++)
            {
                artList.Add(i);
            }

            artList.RemoveAt(artList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_RemoveAtCountIndex()
        {
            var list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(list.Count);
        }

        [TestMethod]
        public void ArtList_RemoveAtCountMinus1Index()
        {
            var artList = new ArtList<int>();

            for (int i = 0; i < 5; i++)
            {
                artList.Add(i);
            }

            var expected = artList.Count - 1;

            artList.RemoveAt(artList.Count - 1);

            var actual = artList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void List_RemoveAtCountMinus1Index()
        {
            var list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            var expected = list.Count - 1;

            list.RemoveAt(list.Count - 1);

            var actual = list.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArtList_RemoveAtZeroIndex()
        {
            var artList = new ArtList<int> { 1 };

            var expected = artList.Count - 1;

            artList.RemoveAt(0);

            var actual = artList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void List_RemoveAtZeroIndex()
        {
            var list = new List<int> { 1 };

            var expected = list.Count - 1;

            list.RemoveAt(0);

            var actual = list.Count;

            Assert.AreEqual(expected, actual);
        }
        #endregion RemoveAt
    }
}