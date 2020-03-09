using System;

namespace ConsoleCalculator
{
    public class Token : IComparable<Token>
    {
        public TokenTypes TokenType { get; private set; }

        public double Number { get; }

        #region ctor
        private Token() {}

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
                    break;

                case (char)TokenTypes.Minus:
                    TokenType = TokenTypes.Minus;
                    break;

                case (char)TokenTypes.Multiplication:
                    TokenType = TokenTypes.Multiplication;
                    break;

                case (char)TokenTypes.Division:
                    TokenType = TokenTypes.Division;
                    break;

                case (char)TokenTypes.OpeningBracket:
                    TokenType = TokenTypes.OpeningBracket;
                    break;

                case (char)TokenTypes.ClosingBracket:
                    TokenType = TokenTypes.ClosingBracket;
                    break;

                default:
                    throw new Exception(string.Format(Settings.UnknownValueTemplate, nameof(TokenTypes), oper));
            }
        }
        #endregion

        public static Token GetStopperToken()
        {
            var token = new Token
            {
                TokenType = TokenTypes.Stopper
            };

            return token;
        }

        public int CompareTo(Token other)
        {
            var tokenTypeComparison = TokenType.CompareTo(other.TokenType);

            if (tokenTypeComparison != 0)
            {
                return tokenTypeComparison;
            }

            return Number.CompareTo(other.Number);
        }

        public override string ToString()
        {
            return $"TokenType={TokenType},\tNumber={Number}";
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
        ClosingBracket = 41,

        Stopper = 10, //LF 
        Unassigned = 127
    }
}