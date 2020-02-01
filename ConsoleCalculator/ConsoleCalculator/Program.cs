using ConsoleCalculator.PolishNotations;
using System;

namespace ConsoleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "0 + 9AsD1  23 -  4 *(5/6)";
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    input += arg;
                }
            }

            var inputProcessor = new InputProcessor();
            var tokens = inputProcessor.GetTokens(input);

            var polishNotationsHelper = new PolishNotationHelper();
            var reversedPolishNotation = polishNotationsHelper.GetReversedPolishNotation(tokens) as ReversedPolishNotation;

            var rpnEvaluationHelper = new RPNEvaluationHelper();
            double result = rpnEvaluationHelper.Evaluate(reversedPolishNotation);

            Console.WriteLine(result);
        }
    }
}