using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleCalculator.Tests.Tests
{
    [TestClass]
    public class InputProcessorTests
    {
        [TestMethod]
        public void GetOperandsAndTokens_0bsPlusBs9AsD1bsBs23bsMinusBsBs4bsMultiplyOpenBracket5Division6CloseBracket_1Plus1expected()
        {
            const string input = "0 + 9AsD1  23 -  4 *(5/6)";
            var expected = new List<char>
            {
                '0',
                '+',
                '9',
                '1',
                '2',
                '3',
                '-',
                '4',
                '*',
                '(',
                '5',
                '/',
                '6',
                ')'
            };

            var processor = new InputProcessor();
            List<char> actual = processor.GetOperandsAndTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        #region Null expected
        [TestMethod]
        public void GetOperandsAndTokens_null_nullExpected()
        {
            string input = null;
            List<char> expected = null;

            var processor = new InputProcessor();
            List<char> actual = processor.GetOperandsAndTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOperandsAndTokens_emptyString_nullExpected()
        {
            string input = string.Empty;
            List<char> expected = null;

            var processor = new InputProcessor();
            List<char> actual = processor.GetOperandsAndTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOperandsAndTokens_bs_nullExpected()
        {
            string input = " ";
            List<char> expected = null;

            var processor = new InputProcessor();
            List<char> actual = processor.GetOperandsAndTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
    }
}