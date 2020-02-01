using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        #region Operations
        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException($"Denominator must not be equal 0.");

            return (double)x / y;
        }
        #endregion
    }
}