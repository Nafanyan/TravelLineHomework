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
        public void Rectangle_NotPositiveLength_Exeption(double input)
        {
            Assert.Throws<ArgumentException>(() => new Circle(input));
        }

        [TestCase(2)]
        [TestCase(21)]
        [TestCase(54)]
        public void CalculateArea_CalculateArea_Area(double input)
        {
            // Arrange
            Circle rectangle = new Circle(input);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculateArea(), Math.PI * input * input);
        }

        [TestCase(2)]
        [TestCase(21)]
        [TestCase(54)]
        public void CalculatePerimeter_CalculatePerimeter_Perimeter(double input)
        {
            // Arrange
            Circle rectangle = new Circle(input);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculatePerimeter(), 2 * Math.PI * input);
        }
    }
}