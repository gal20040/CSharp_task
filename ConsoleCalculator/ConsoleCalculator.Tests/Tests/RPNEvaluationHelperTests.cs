using ConsoleCalculator.PolishNotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Tests.Tests
{
    [TestClass]
    public class RPNEvaluationHelperTests
    {
        [TestMethod]
        public void Evaluate_9119dot6666666666661Expected()
        {
            const double expected = 9119.6666666666661;

            const string input = "0 + 9AsD1  23 -  4 *(5/6)";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Expected()
        {
            const double expected = 8.36;

            const string input = "1.1asd   +2,2*sd3.3ddd";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_8dot36Expected()
        {
            const double expected = 8.36;

            const string input = "1.1asd   +2.2*sd3.3ddd";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_10dot89Expected()
        {
            const double expected = 10.89;

            const string input = "(1.1asd   +2.2c)x*sd3.3ddd";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_111111111Expected()
        {
            const double expected = 111111111;

            const string input = "12345679*9";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_1111111101Expected()
        {
            const double expected = 1111111101;

            const string input = "123456789*9";
            var actual = Evaluate(input);

            Assert.AreEqual(expected, actual);
        }

        private double Evaluate(string input)
        {
            var inputProcessor = new InputProcessor();
            var tokens = inputProcessor.GetTokens(input);

            var polishNotationsHelper = new PolishNotationHelper();
            var reversedPolishNotation = polishNotationsHelper.GetReversedPolishNotation(tokens) as ReversedPolishNotation;

            var rpnEvaluationHelper = new RPNEvaluationHelper();

            return rpnEvaluationHelper.Evaluate(reversedPolishNotation);
        }
    }
}