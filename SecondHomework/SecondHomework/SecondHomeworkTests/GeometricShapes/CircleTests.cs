using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondHomework.GeometricShapes;

namespace SecondHomework.GeometricShapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void Rectangle_ValidateData_Exeption()
        {
            // Arrange
            Circle rectangle = new Circle(4);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => rectangle.Radius = -5);
        }

        [TestMethod()]
        public void Rectangle_ValidateData_NoExeption()
        {
            // Arrange
            Circle rectangle = new Circle(4);

            // Act & Assert
            Assert.AreEqual(rectangle.Radius, 4);
        }

        [TestMethod()]
        public void Rectangle_CalculateArea_Area()
        {
            // Arrange
            Circle rectangle = new Circle(4);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculateArea(), Math.PI * 4 * 4);
        }

        [TestMethod()]
        public void Rectangle_CalculatePerimeter_Perimeter()
        {
            // Arrange
            Circle rectangle = new Circle(4);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculatePerimeter(), 2 * Math.PI * 4);
        }
    }
}