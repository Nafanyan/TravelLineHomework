﻿using Calculator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Models.Tests
{
    [TestClass()]
    public class CalculatorRevPolTests
    {
        [TestCase("1 2 + 10 12 * - 2 10 / + 12 8 * -", "-212,8")]
        [TestCase("11 2 - 9 12 * + 4 -", "113")]
        [TestCase("90 99 - 12 + 7 123 / -", "2,943")]
        public void Start_CorrectData_RightAnswer(string input, string output)
        {
            // Arrange
            CalculatorRevPol calculator = new CalculatorRevPol();

            // Act
            calculator.Start(input);

            // Assert
            Assert.AreEqual(calculator.Result, output);
        }

        [TestCase("1 2 + 10 12 * - 2 10 / + 12 8 *")]
        [TestCase("11 2 2 ")]
        [TestCase("90 9")]
        [TestCase("90 + 9")]
        [TestCase("90  - - 9")]
        [TestCase("9asdasf  - asd asdsa")]
        public void Start_NotCorrectData_StringError(string input)
        {
            // Arrange
            CalculatorRevPol calculator = new CalculatorRevPol();

            // Act & Assert
            Assert.Throws<CalculatorRevPolArgumentException>(() => calculator.Start(input));


        }
    }
}