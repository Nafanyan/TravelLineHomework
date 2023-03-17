using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace SecondHomework.GeometricShapes.Tests
{

    [TestClass()]
    public class SquareTests
    {

        [TestCase(-10)]
        [TestCase(-12)]
        [TestCase(-5)]
        public void Constructor_NotPositiveLength_Exeption(double input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Square(input));
        }

        [TestCase(10)]
        [TestCase(12)]
        [TestCase(5)]
        public void CalculateArea_ValidInput_CorrectAnswera(double input)
        {
            // Arrange
            Square square = new Square(input);
            double area = input * input;

            // Act & Assert
            Assert.AreEqual(square.CalculateArea(), area);
        }

        [TestCase(10)]
        [TestCase(0.1)]
        [TestCase(123)]
        public void CalculatePerimeter_ValidInput_CorrectAnswer(double input)
        {
            // Arrange
            Square square = new Square(input);
            double perimeter = input * 4;

            // Act & Assert
            Assert.AreEqual(square.CalculatePerimeter(), perimeter);
        }


    }
}