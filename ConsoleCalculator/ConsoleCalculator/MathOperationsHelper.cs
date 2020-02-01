using System;

namespace ConsoleCalculator
{
    public class MathOperationsHelper
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
                throw new DivideByZeroException("Знаменатель не должен быть равен 0.");

            return (double)x / y;
        }
        #endregion
    }
}