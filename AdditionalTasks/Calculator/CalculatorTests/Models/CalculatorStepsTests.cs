﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Models.Tests
{
    [TestClass()]
    public class CalculatorStepsTests
    {
        [TestCase("1 + 22", "23")]
        [TestCase("1 - 2", "-1")]
        [TestCase("9 / 2", "4,5")]
        [TestCase("13 * 5", "65")]
        public void Start_CorrectData_RightAnswer(string input, string output)
        {
            // Arrange
            CalculatorSteps calculator = new CalculatorSteps();

            // Act
            calculator.Start(input);

            // Assert
            Assert.AreEqual(calculator.Result(), output);
        }

        [TestCase("1 2 3", "Input error")]
        [TestCase("     ", "Input error")]
        [TestCase("- - 1", "Input error")]
        [TestCase("/    ", "Input error")]
        [TestCase("- 2 +", "Input error")]
        public void Start_NotCorrectData_StringError(string input, string output)
        {
            // Arrange
            CalculatorSteps calculator = new CalculatorSteps();

            // Act
            calculator.Start(input);

            // Assert
            Assert.AreEqual(calculator.Result(), output);
        }
    }
}