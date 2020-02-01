using ConsoleCalculator.PolishNotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleCalculator.Tests.Tests
{
    [TestClass]
    public class PolishNotaionHelperTests
    {
        [TestMethod]
        public void GetReversedPolishNotation_Test()
        {
            const string input = "0 + 9AsD1  23 -  4 *(5/6)";

            PolishNotation expected = new ReversedPolishNotation();
            expected.Tokens.Enqueue(new Token(0));
            expected.Tokens.Enqueue(new Token(9123));
            expected.Tokens.Enqueue(new Token('+'));
            expected.Tokens.Enqueue(new Token(4));
            expected.Tokens.Enqueue(new Token(5));
            expected.Tokens.Enqueue(new Token(6));
            expected.Tokens.Enqueue(new Token('/'));
            expected.Tokens.Enqueue(new Token('*'));
            expected.Tokens.Enqueue(new Token('-'));

            var inputProcessor = new InputProcessor();
            Queue<Token> inputTokens = inputProcessor.GetTokens(input); //лень вручную наполнять очередь с токенами, поэтому использую InputProcessor

            var polishNotaionHelper = new PolishNotaionHelper();
            var actual = polishNotaionHelper.GetReversedPolishNotation(inputTokens);

            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.AreEqual(expected.Tokens.Count, actual.Tokens.Count);

            while (expected.Tokens.Count > 0)
            {
                var exp = expected.Tokens.Dequeue();
                var act = actual.Tokens.Dequeue();
                Assert.AreEqual(exp.GetType(), act.GetType());

                //Assert.AreEqual(exp, act); //'Сбой Assert.AreEqual. Ожидается: <ConsoleCalculator.Token>. Фактически: <ConsoleCalculator.Token>. '

                const byte zero = 0;
                Assert.AreEqual(exp.CompareTo(act), zero, $"\nexpected: {exp.ToString()}" +
                                                          $"\nactual:   {act.ToString()}");
            }
        }
    }
}