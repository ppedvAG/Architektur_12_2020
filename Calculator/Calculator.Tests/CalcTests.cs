using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_5_and_8_results_13()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 8);

            //Assert
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(5, 4, 9)]
        [DataRow(-2, 4, 2)]
        [DataRow(-2, -4, -6)]
        public void Calc_Sum(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();


            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }
}
