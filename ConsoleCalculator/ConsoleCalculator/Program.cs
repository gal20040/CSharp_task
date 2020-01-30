using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            if (args.Length > 0)
                foreach (var arg in args)
                {
                    input += arg;
                }
            else
                input = "3+1";

            var calc = new Calculator();

            Console.WriteLine(calc.Sum(1, 10));
            Console.WriteLine(calc.Sum(1, -10));
            Console.WriteLine(calc.Divide(1, 10));
            Console.WriteLine(calc.Multiply(2, 10));
            Console.WriteLine(calc.Subtract(1, 10));



            Console.WriteLine(input);
            Console.WriteLine(args.Length);

            Console.ReadLine();
        }
    }
}