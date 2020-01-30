using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCalculator.Tests.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        #region Sum
        [TestMethod]
        public void Sum_15dot1and30dot3_45dot4expected()
        {
            const double x = 15.1d;
            const double y = 30.3d;
            const double expected = 45.4d;

            var calc = new Calculator();
            var actual = calc.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sum_minus15dot2and40dot9_25dot7expected()
        {
            const double x = -15.2d;
            const double y = 40.9d;
            const double expected = 25.7d;

            var calc = new Calculator();
            var actual = calc.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sum_0and0_0expected()
        {
            const int x = 0;
            const int y = 0;
            const int expected = 0;

            var calc = new Calculator();
            var actual = calc.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Subtract
        [TestMethod]
        public void Subtract_15and30_Minus15expected()
        {
            const int x = 15;
            const int y = 30;
            const int expected = -15;

            var calc = new Calculator();
            var actual = calc.Subtract(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subtract_minus15dot1and40dot4_minus55dot5expected()
        {
            const double x = -15.1d;
            const double y = 40.4d;
            const double expected = -55.5d;

            var calc = new Calculator();
            var actual = calc.Subtract(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subtract_0and0_0expected()
        {
            const int x = 0;
            const int y = 0;
            const int expected = 0;

            var calc = new Calculator();
            var actual = calc.Subtract(x, y);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Multiply
        [TestMethod]
        public void Multiply_15dot1and30dot2_456dot02expected()
        {
            const double x = 15.1d;
            const double y = 30.2d;
            const double expected = 456.02d;

            var calc = new Calculator();
            var actual = calc.Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_minus15dot2and40dot7_minus618dot64expected()
        {
            const double x = -15.2d;
            const double y = 40.7d;
            const double expected = -618.64d;

            var calc = new Calculator();
            var actual = calc.Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_0and0_0expected()
        {
            const int x = 0;
            const int y = 0;
            const int expected = 0;

            var calc = new Calculator();
            var actual = calc.Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_10dot5and0_0expected()
        {
            const double x = 10.5d;
            const int y = 0;
            const int expected = 0;

            var calc = new Calculator();
            var actual = calc.Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Divide
        [TestMethod]
        public void Divide_0dot3andMinus0dot7_minus0dot4285714285714286expected()
        {
            const double x = 0.3d;
            const double y = -0.7d;
            const double expected = -0.4285714285714286d;

            var calc = new Calculator();
            double actual = calc.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide_minus45andMinus15_3expected()
        {
            const int x = -45;
            const int y = -15;
            const double expected = 3;

            var calc = new Calculator();
            double actual = calc.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_0and0_DivideByZeroExceptionExpected()
        {
            const int x = 0;
            const int y = 0;

            var calc = new Calculator();

            var actual = calc.Divide(x, y);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_10and0_DivideByZeroExceptionExpected()
        {
            const int x = 10;
            const int y = 0;

            var calc = new Calculator();

            var actual = calc.Divide(x, y);
        }
        #endregion
    }
}