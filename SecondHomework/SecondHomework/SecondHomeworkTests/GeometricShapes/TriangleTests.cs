using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondHomework.GeometricShapes;

namespace SecondHomework.GeometricShapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {

        [TestMethod()]
        public void Triangle_ValidateData_Exeption()
        {
            // Arrange
            Triangle triangle = new Triangle(4, 12, 10);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => triangle.FirstSide = -4);
            Assert.ThrowsException<ArgumentException>(() => triangle.SecondSide = -12);
            Assert.ThrowsException<ArgumentException>(() => triangle.ThirdSide = -10);
        }

        [TestMethod()]
        public void Triangle_ValidateData_NoExeption()
        {
            // Arrange
            Triangle triangle = new Triangle(4, 12, 10);

            // Act & Assert
            Assert.AreEqual(triangle.FirstSide, 4);
            Assert.AreEqual(triangle.SecondSide, 12);
            Assert.AreEqual(triangle.ThirdSide, 10);

        }

        [TestMethod()]
        public void Triangle_CalculateArea_Area()
        {
            // Arrange
            Triangle triangle = new Triangle(4, 12, 10);
            double p = triangle.CalculatePerimeter() / 2;
            //return 

            // Act & Assert
            Assert.AreEqual(triangle.CalculateArea(), 
                Math.Sqrt(p * (p - triangle.FirstSide) * (p - triangle.SecondSide) * (p - triangle.ThirdSide)));
        }

        [TestMethod()]
        public void Triangle_CalculatePerimeter_Perimeter()
        {
            // Arrange
            Triangle triangle = new Triangle(4, 12, 10);

            // Act & Assert
            Assert.AreEqual(triangle.CalculatePerimeter(), 26);
        }
    }
}