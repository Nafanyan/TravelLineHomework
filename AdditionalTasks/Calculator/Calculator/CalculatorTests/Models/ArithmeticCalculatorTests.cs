using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Models.Tests
{
    [TestClass()]
    public class ArithmeticCalculatorTests
    {
        [TestCase("1 2 + 10 12 * - 2 10 / + 12 8 * -", "-212,8")]
        [TestCase("11 2 - 9 12 * + 4 -", "113")]
        [TestCase("90 99 - 12 + 7 123 / -", "2,943")]
        public void Start_CorrectData_RightAnswer(string input, string output)
        {
            // Arrange
            ArithmeticCalculator calculator = new ArithmeticCalculator();

            // Act
            calculator.Start(input);

            // Assert
            Assert.AreEqual(calculator.Result(), output);
        }

        [TestCase("1 2 + 10 12 * - 2 10 / + 12 8 *", "Input error")]
        [TestCase("11 2 2 ", "Input error")]
        [TestCase("90 9", "Input error")]
        public void Start_NotCorrectData_StringError(string input, string output)
        {
            // Arrange
            ArithmeticCalculator calculator = new ArithmeticCalculator();

            // Act
            calculator.Start(input);

            // Assert
            Assert.AreEqual(calculator.Result(), output);
        }
    }
}