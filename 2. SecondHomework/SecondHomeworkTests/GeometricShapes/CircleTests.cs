using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace SecondHomework.GeometricShapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestCase(-10)]
        [TestCase(-12)]
        [TestCase(-5)]
        public void Constructor_NotPositiveLength_Exeption(double input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Circle(input));
        }

        [TestCase(2)]
        [TestCase(21)]
        [TestCase(54)]
        public void CalculateArea_CalculateArea_Area(double input)
        {
            // Arrange
            Circle сircle = new Circle(input);
            double area = Math.PI * input * input;

            // Act & Assert
            Assert.AreEqual(сircle.CalculateArea(), area);
        }

        [TestCase(2)]
        [TestCase(21)]
        [TestCase(54)]
        public void CalculatePerimeter_CalculatePerimeter_Perimeter(double input)
        {
            // Arrange
            Circle сircle = new Circle(input);
            double perimeter = 2 * Math.PI * input;

            // Act & Assert
            Assert.AreEqual(сircle.CalculatePerimeter(), perimeter);
        }
    }
}