using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleCalculator.Tests.Tests
{
    [TestClass]
    public class InputProcessorTests
    {
        #region CleanUpInput
        [TestMethod]
        public void CleanUpInput_0bsPlusBs9AsD1bsBs23bsMinusBsBs4bsMultiplyOpenBracket5Division6CloseBracket_0Plus9123Minus4MultyOpBr5Div6ClBrExpected()
        {
            const string input = "0 + 9AsD1  23 -  4 *(5/6)";
            var expected = "0+9123-4*(5/6)";

            var processor = new InputProcessor();
            var actual = processor.CleanUpInput(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CleanUpInput_0bsbsbs_0expected()
        {
            const string input = "0   ";
            var expected = "0";

            var processor = new InputProcessor();
            var actual = processor.CleanUpInput(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CleanUpInput_bsbs0_0expected()
        {
            const string input = "  0";
            var expected = "0";

            var processor = new InputProcessor();
            var actual = processor.CleanUpInput(input);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        [TestMethod]
        public void PropagateFractionSeparator_0bs1dot2comma3_0bs1dot2dot3expected()
        {
            const string input = "0 1.2,3";
            var expected = "0 1,2,3";

            var processor = new InputProcessor();
            var actual = processor.PropagateFractionSeparator(input);

            Assert.AreEqual(expected, actual);
        }

        #region DoesContainDotsAndCommas
        [TestMethod]
        public void DoesContainDotsAndCommas_0dot1plus0dot2_FalseExpected()
        {
            const string input = "0.1+0.2";

            var processor = new InputProcessor();

            var actual = processor.DoesContainDotsAndCommas(input);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void DoesContainDotsAndCommas_0comma1plus0comma2_FalseExpected()
        {
            const string input = "0,1+0,2";

            var processor = new InputProcessor();

            var actual = processor.DoesContainDotsAndCommas(input);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DoesContainDotsAndCommas_0dot1plus0comma2_ExceptionExpected()
        {
            const string input = "0.1+0,2";

            var processor = new InputProcessor();

            var actual = processor.DoesContainDotsAndCommas(input);
        }
        #endregion

        #region IsNumericPart
        [TestMethod]
        public void IsNumericPart_From0To9AndComma_TrueExpected()
        {
            var processor = new InputProcessor();

            const string dotAndDigits = ",0123456789";

            foreach (var @char in dotAndDigits)
            {
                Assert.IsTrue(processor.IsNumericPart(@char));
            }
        }

        [TestMethod]
        public void IsNumericPart_AllCharsExceptFrom0To9AndDot_FalseExpected()
        {
            var processor = new InputProcessor();

            for (char @char = (char)32; @char <= (char)127; @char++)
            {
                if ((@char >= '0' && @char <= '9')
                    || @char == Settings.fractionSeparator)
                {
                    continue;
                }

                Assert.IsFalse(processor.IsNumericPart(@char));
            }
        }
        #endregion

        #region IsOperatorOrBracket
        [TestMethod]
        public void IsOperatorOrBracket_OperatorsAndBrackets_TrueExpected()
        {
            var processor = new InputProcessor();
            const string operatorsAndBrackets = "+-*/()";

            foreach (var @char in operatorsAndBrackets)
            {
                Assert.IsTrue(processor.IsOperatorOrBracket(@char));
            }
        }

        [TestMethod]
        public void IsOperatorOrBracket_AllCharsExceptOperatorsAndBrackets_FalseExpected()
        {
            var processor = new InputProcessor();
            const string operatorsAndBrackets = "+-*/()";


            for (char @char = (char)32; @char <= (char)127; @char++)
            {
                if (operatorsAndBrackets.Contains(@char.ToString()))
                {
                    continue;
                }

                Assert.IsFalse(processor.IsOperatorOrBracket(@char));
            }
        }
        #endregion

        #region GetTokens
        [TestMethod]
        public void GetTokens_0bsPlusBs9AsD1bsBs23bsMinusBsBs4bsMultiplyOpenBracket5Division6CloseBracket_0Plus9123Minus4MultyOpBr5Div6ClBrExpected()
        {
            const string input = "0 + 9AsD1  23 -  4 *(5/6)";
            var expected = new Queue<Token>();
            expected.Enqueue(Token.GetStopperToken());
            expected.Enqueue(new Token(0));
            expected.Enqueue(new Token('+'));
            expected.Enqueue(new Token(9123));
            expected.Enqueue(new Token('-'));
            expected.Enqueue(new Token(4));
            expected.Enqueue(new Token('*'));
            expected.Enqueue(new Token('('));
            expected.Enqueue(new Token(5));
            expected.Enqueue(new Token('/'));
            expected.Enqueue(new Token(6));
            expected.Enqueue(new Token(')'));
            expected.Enqueue(Token.GetStopperToken());

            var processor = new InputProcessor();
            Queue<Token> actual = processor.GetTokens(input);

            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.AreEqual(expected.Count, actual.Count);

            while (expected.Count > 0)
            {
                var exp = expected.Dequeue();
                var act = actual.Dequeue();
                Assert.AreEqual(exp.GetType(), act.GetType());

                //Assert.AreEqual(exp, act); //'Сбой Assert.AreEqual. Ожидается: <ConsoleCalculator.Token>. Фактически: <ConsoleCalculator.Token>. '

                const byte zero = 0;
                Assert.AreEqual(exp.CompareTo(act), zero);
            }
        }

        [TestMethod]
        public void TokensToString_0bsPlusBs9AsD1bsBs23bsMinusBsBs4bsMultiplyOpenBracket5Division6CloseBracket_0Plus9123Minus4MultyOpBr5Div6ClBrExpected()
        {
            var processor = new InputProcessor();

            const string input = "0 + 9AsD1  23 -  4 *(5/6)";
            var expected = "0+9123-4*(5/6)";

            var actual = processor.TokensToString(input);

            Assert.AreEqual(expected, actual);
        }

        #region Null expected
        [TestMethod]
        public void GetTokens_null_EmptyQueueExpected()
        {
            const string input = null;
            Queue<Token> expected = new Queue<Token>();

            var processor = new InputProcessor();
            Queue<Token> actual = processor.GetTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTokens_emptyString_EmptyQueueExpected()
        {
            string input = string.Empty;
            Queue<Token> expected = new Queue<Token>();

            var processor = new InputProcessor();
            Queue<Token> actual = processor.GetTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTokens_bs_EmptyQueueExpected()
        {
            const string input = " ";
            Queue<Token> expected = new Queue<Token>();

            var processor = new InputProcessor();
            Queue<Token> actual = processor.GetTokens(input);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
        #endregion
    }
}