using System;

namespace ConsoleCalculator
{
    public class Token : IComparable<Token>
    {
        public TokenTypes TokenType { get; set; }

        public double Number { get; set; }

        public int Priority { get; set; }

        #region ctor
        public Token(double number)
        {
            TokenType = TokenTypes.Number;
            Number = number;
        }

        public Token(char oper)
        {
            switch (oper)
            {
                case (char)TokenTypes.Plus:
                    TokenType = TokenTypes.Plus;
                    Priority = 1;
                    break;

                case (char)TokenTypes.Minus:
                    TokenType = TokenTypes.Minus;
                    Priority = 1;
                    break;

                case (char)TokenTypes.Multiplication:
                    TokenType = TokenTypes.Multiplication;
                    Priority = 2;
                    break;

                case (char)TokenTypes.Division:
                    TokenType = TokenTypes.Division;
                    Priority = 2;
                    break;

                case (char)TokenTypes.OpeningBracket:
                    TokenType = TokenTypes.OpeningBracket;
                    break;

                case (char)TokenTypes.ClosingBracket:
                    TokenType = TokenTypes.ClosingBracket;
                    break;

                default:
                    throw new Exception($"Unexpected {nameof(TokenTypes)} value: {oper}.");
            }
        }
        #endregion

        public int CompareTo(Token other)
        {
            var tokenTypeComparison = TokenType.CompareTo(other.TokenType);

            if (tokenTypeComparison != 0)
            {
                return tokenTypeComparison;
            }

            var priorityComparison = Priority.CompareTo(other.Priority);

            if (priorityComparison != 0)
            {
                return priorityComparison;
            }

            return Number.CompareTo(other.Number);
        }
    }

    public enum TokenTypes
    {
        Number,
        Plus = 43,
        Minus = 45,
        Multiplication = 42,
        Division = 47,
        OpeningBracket = 40,
        ClosingBracket = 41
    }
}