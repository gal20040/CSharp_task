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

            Console.WriteLine(input);
            Console.WriteLine(args.Length);

            //Console.ReadLine();
        }
    }
}