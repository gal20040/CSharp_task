using DataStructures.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructures.Tests
{
    [TestClass]
    public class ArtList_Tests : BaseTest
    {
        [TestMethod]
        public void Count_EmptyList()
        {
            var artList = new ArtList<int>();
            var list = new List<int>();

            var listsComparer = new ListsComparer();
            var isEqual = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(isEqual, comparisonResult);
        }

        #region Add
        [TestMethod]
        public void Add_100Items()
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
        #endregion

        #region RemoveAt
        [TestMethod]
        public void RemoveAt_AllIndexesThatMultiplesTen()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_RemoveAt_Minus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out _, out ArtList<int> artList, count);

            artList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_RemoveAt_Minus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out List<int> list, out _, count);

            list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_RemoveAt_CountIndex()
        {
            const byte count = 5;
            PrepareListAndArtList(out _, out ArtList<int> artList, count);

            artList.RemoveAt(artList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_RemoveAt_CountIndex()
        {
            const byte count = 5;
            PrepareListAndArtList(out List<int> list, out _, count);

            list.RemoveAt(list.Count);
        }

        [TestMethod]
        public void ArtList_RemoveAt_CountMinus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out _, out ArtList<int> artList, count);

            var expected = artList.Count - 1;

            artList.RemoveAt(artList.Count - 1);

            var actual = artList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void List_RemoveAt_CountMinus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out List<int> list, out _, count);

            var expected = list.Count - 1;

            list.RemoveAt(list.Count - 1);

            var actual = list.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArtList_RemoveAt_ZeroIndex()
        {
            var artList = new ArtList<int> { 1 };

            var expected = artList.Count - 1;

            artList.RemoveAt(0);

            var actual = artList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void List_RemoveAt_ZeroIndex()
        {
            var list = new List<int> { 1 };

            var expected = list.Count - 1;

            list.RemoveAt(0);

            var actual = list.Count;

            Assert.AreEqual(expected, actual);
        }
        #endregion RemoveAt

        #region Remove
        [TestMethod]
        public void Remove_ItemsThatMultiplesTen()
        {
            const byte count = 100;
            PrepareListAndArtList(out List<int> list, out ArtList<int> artList, count);

            var listsComparer = new ListsComparer();
            bool result;
            string comparisonResult;

            //precheck
            result = listsComparer.IsEqual(list, artList, out comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            //get numbers from -10 to 100 inclusive, which are multiples of 10
            for (int number = -10; number <= 100; number += 10)
            {
                artList.Remove(number);
                list.Remove(number);
                result = listsComparer.IsEqual(list, artList, out comparisonResult);
                Assert.IsTrue(result, comparisonResult);
            }
        }
        #endregion

        #region IndexOf
        [TestMethod]
        public void IndexOf_ItemsThatMultiplesTen()
        {
            const byte count = 100;
            PrepareListAndArtList(out List<int> list, out ArtList<int> artList, count);

            //precheck
            var listsComparer = new ListsComparer();
            bool result = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            int expected, actual;

            //get numbers from -20 to 110 inclusive, which are multiples of 10
            for (int number = -20; number <= 110; number += 10)
            {
                expected = artList.IndexOf(number);
                actual = list.IndexOf(number);
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

        #region Insert
        [TestMethod]
        public void Insert_ItemsWithIncreasingCapacity()
        {
            const byte count = 14;
            PrepareListAndArtList(out List<int> list, out ArtList<int> artList, count);

            //precheck
            var listsComparer = new ListsComparer();
            bool result = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            int index, value;

            for (int i = 0; i < 5; i++)
            {
                index = (i + 1) * 2;
                value = index * 100;
                artList.Insert(index, value);
                list.Insert(index, value);

                result = listsComparer.IsEqual(list, artList, out comparisonResult);
                Assert.IsTrue(result, comparisonResult);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_Insert_AtMinus1Index()
        {
            const byte count = 0;
            PrepareListAndArtList(out _, out ArtList<int> artList, count);

            const int index = -1;
            const int value = 100;
            artList.Insert(index, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_Insert_AtMinus1Index()
        {
            const byte count = 0;
            PrepareListAndArtList(out List<int> list, out _, count);

            const int index = -1;
            const int value = 100;
            list.Insert(index, value);
        }

        [TestMethod]
        public void Insert_ItemsAtZeroIndex()
        {
            const byte count = 0;
            PrepareListAndArtList(out List<int> list, out ArtList<int> artList, count);

            //precheck
            var listsComparer = new ListsComparer();
            bool result = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            const int index = 0;
            const int value = 100;
            artList.Insert(index, value);
            list.Insert(index, value);

            result = listsComparer.IsEqual(list, artList, out comparisonResult);
            Assert.IsTrue(result, comparisonResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArtList_Insert_AtCountPlus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out _, out ArtList<int> artList, count);

            var index = artList.Count + 1;
            const int value = 100;
            artList.Insert(index, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void List_Insert_AtCountPlus1Index()
        {
            const byte count = 5;
            PrepareListAndArtList(out List<int> list, out _, count);

            var index = list.Count + 1;
            const int value = 100;
            list.Insert(index, value);
        }

        [TestMethod]
        public void Insert_ItemsAtCountIndex()
        {
            const byte count = 5;
            PrepareListAndArtList(out List<int> list, out ArtList<int> artList, count);

            //precheck
            var listsComparer = new ListsComparer();
            bool result = listsComparer.IsEqual(list, artList, out var comparisonResult);
            Assert.IsTrue(result, comparisonResult);

            int index, value;

            for (int i = 0; i < 3; i++)
            {
                index = artList.Count;
                value = index * 100;
                artList.Insert(index, value);
                list.Insert(index, value);

                result = listsComparer.IsEqual(list, artList, out comparisonResult);
                Assert.IsTrue(result, comparisonResult);
            }
        }
        #endregion
    }
}