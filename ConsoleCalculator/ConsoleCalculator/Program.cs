using ConsoleCalculator.PolishNotations;
using System;

namespace ConsoleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0
                || args[0] == "-h"
                || args[0] == "/h"
                || args[0] == "-?"
                || args[0] == "/?")
            {
                Console.WriteLine("Пожалуйста, укажите математическое выражение.");
                ShowHelpMessage();

                return;
            }

            string input = "";
            if (args.Length > 0)
            {
                int i = 0;
                if (args[0] == "-d")
                {
                    Settings.Debug = true;
                    i = 1;
                }

                for (; i < args.Length; i++)
                {
                    input += args[i];
                }
            }

            try
            {
                var inputProcessor = new InputProcessor();
                var tokens = inputProcessor.GetTokens(input);

                var polishNotationsHelper = new PolishNotationHelper();
                var reversedPolishNotation = polishNotationsHelper.GetReversedPolishNotation(tokens) as ReversedPolishNotation;

                var rpnEvaluationHelper = new RPNEvaluationHelper();
                double result = rpnEvaluationHelper.Evaluate(reversedPolishNotation);

                Console.WriteLine($"Результат: {result}");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Некорректное входное выражение: {input}");
                ShowHelpMessage();
            }
            catch (Exception ex)
            {
                if (Settings.Debug)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Некорректное входное выражение: {input}");
                ShowHelpMessage();
            }
        }

        public static void ShowHelpMessage()
        {
            Console.WriteLine($"Поддерживаются математические операции: {(char)TokenTypes.Plus}, {(char)TokenTypes.Minus}, {(char)TokenTypes.Multiplication}, {(char)TokenTypes.Division}");
            Console.WriteLine("Поддерживаются целые и дробные числа.");
        }
    }
}