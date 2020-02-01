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
        public void Evaluate_9dot36Expected()
        {
            const double expected = 9.36;

            const string input = "2.1asd   +2.2*sd3.3ddd";
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