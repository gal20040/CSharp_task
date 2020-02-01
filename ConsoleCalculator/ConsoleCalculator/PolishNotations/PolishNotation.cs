using System.Collections.Generic;

namespace ConsoleCalculator.PolishNotations
{
    public class PolishNotation
    {
        public Queue<Token> Tokens { get; set; }

        public PolishNotation() => Tokens = new Queue<Token>();
    }
}