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

        public void Square_NotPositiveLength_Exeption(double input)
        {
            Assert.Throws<ArgumentException>(() => new Square(-1));
        }


        [TestCase(10)]
        [TestCase(12)]
        [TestCase(5)]

        public void CalculateArea_ValidInput_CorrectAnswera(double input)
        {
            // Arrange
            Square square = new Square(input);

            // Act & Assert
            Assert.That(square.CalculateArea(), Is.EqualTo(input * input));
        }

        [TestCase(10)]
        [TestCase(0.1)]
        [TestCase(123)]
        public void CalculatePerimeter_ValidInput_CorrectAnswer(double input)
        {
            // Arrange
            Square square = new Square(input);

            // Act & Assert
            Assert.AreEqual(square.CalculatePerimeter(), input * 4);
        }


    }
}