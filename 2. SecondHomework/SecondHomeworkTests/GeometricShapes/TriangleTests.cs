using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace SecondHomework.GeometricShapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {

        [TestCase(1, 2, 2)]
        [TestCase(9, 10, 12)]
        [TestCase(44, 55, 33)]
        public void CalculateArea_CalculateArea_Area(double firstSide, double secoSide, double thirSide)
        {
            // Arrange
            Triangle triangle = new Triangle(firstSide, secoSide, thirSide);
            double p = triangle.CalculatePerimeter() / 2;
            double area = Math.Sqrt(p * (p - firstSide) * (p - secoSide) * (p - thirSide));

            // Act & Assert
            Assert.AreEqual(triangle.CalculateArea(), area);
        }

        [TestCase(1, 2, 2)]
        [TestCase(9, 10, 12)]
        [TestCase(44, 55, 33)]
        public void CalculatePerimeter_CalculatePerimeter_Perimeter(double firstSide, double secoSide, double thirSide)
        {
            // Arrange
            Triangle triangle = new Triangle(firstSide, secoSide, thirSide);
            double perimeter = firstSide + secoSide + thirSide;

            // Act & Assert
            Assert.AreEqual(triangle.CalculatePerimeter(), perimeter);
        }
    }
}