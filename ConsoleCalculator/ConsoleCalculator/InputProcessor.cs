using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class InputProcessor
    {
        public List<char> GetOperandsAndTokens(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var tokens = new List<char>();
            //var unexpectedSymbols = new List<char>();

            foreach (var symbol in input)
            {
                if ((symbol >= '0' && symbol <= '9')
                    || symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/'
                    || symbol == '(' || symbol == ')')
                {
                    tokens.Add(symbol);
                }
                //else if (symbol == ' ')
                //{
                //    continue;
                //}
                //else
                //{
                //    unexpectedSymbols.Add(symbol);
                //}
            }

            //if (unexpectedSymbols.Count > 0)
            //{
            //    throw new Exception($"Incorrect symbols: {unexpectedSymbols.ToString()} \nin the input: {input}");
            //}

            return tokens;
        }
    }
}