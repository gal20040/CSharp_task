using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class InputProcessor
    {
        private const char fractionSeparator = '.';
        private const string commaSeparator = ",";

        public Queue<Token> GetTokens(string input)
        {
            var tokens = new Queue<Token>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return tokens;
            }

            DoesContainDotsAndCommas(input);
            input = PropagateFractionSeparator(input);
            input = CleanUpInput(input);

            if (string.IsNullOrWhiteSpace(input))
            {
                return tokens;
            }

            var number = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];
                if (IsNumericPart(symbol))
                {
                    //текущий символ - цифра или точка
                    number += symbol; //прицепим его к строковому представлению number для дальнейшего парсинга в числовое представление
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(number))
                    {
                        //строковое представление number не нулевое
                        tokens.Enqueue(new Token(double.Parse(number)));
                        number = string.Empty;
                    }

                    if (IsOperatorOrBracket(symbol))
                    {
                        tokens.Enqueue(new Token(symbol));
                    }
                }
            }

            return tokens;
        }

        public string TokensToString(string input)
        {
            var tokens = GetTokens(input);
            var result = "";

            foreach (var token in tokens)
            {
                if (token.TokenType == TokenTypes.Number)
                {
                    result += token.Number;
                }
                else
                {
                    result += (char)token.TokenType;
                }
            }

            return result;
        }

        public string CleanUpInput(string input)
        {
            for (int i = 0; i < input.Length; )
            {
                var @char = input[i];

                if (IsNumericPart(@char)
                    || IsOperatorOrBracket(@char))
                {
                    i++;
                    continue;
                }

                input = input.Replace(@char.ToString(), "");
            }

            return input;
        }

        public string PropagateFractionSeparator(string input)
        {
            return input.Replace(commaSeparator, fractionSeparator.ToString());
        }

        /// <summary>
        /// Если в составе input есть и '.', и ',', то выбросить Exception.
        /// Иначе вернуть false.
        /// </summary>
        /// <param name="input">Проверяемая строка</param>
        /// <returns></returns>
        public bool DoesContainDotsAndCommas(string input)
        {
            if (input.Contains(fractionSeparator.ToString()) && input.Contains(commaSeparator))
                throw new Exception($"Входная строка содержит и '{fractionSeparator}', и '{commaSeparator}' - оставьте либо одно, либо другое.");

            return false;
        }

        /// <summary>
        /// Проверяет, является ли переданный символ цифрой или точкой/запятой
        /// </summary>
        /// <param name="char">Символ для проверки</param>
        /// <returns>Результат проверки</returns>
        public bool IsNumericPart(char @char)
        {
            return char.IsDigit(@char) || @char == fractionSeparator;
        }

        /// <summary>
        /// Проверяет, является ли переданный символ +, -, *, /, ( или )
        /// </summary>
        /// <param name="char">Символ для проверки</param>
        /// <returns>Результат проверки</returns>
        public bool IsOperatorOrBracket(char @char)
        {
            switch (@char)
            {
                case (char)TokenTypes.Plus:
                case (char)TokenTypes.Minus:
                case (char)TokenTypes.Multiplication:
                case (char)TokenTypes.Division:
                case (char)TokenTypes.OpeningBracket:
                case (char)TokenTypes.ClosingBracket:
                    return true;

                default:
                    return false;
            }
        }
    }
}