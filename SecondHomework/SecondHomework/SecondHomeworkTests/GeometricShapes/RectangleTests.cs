using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondHomework.GeometricShapes;


namespace SecondHomework.GeometricShapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void Rectangle_ValidateData_NoExeption()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(4, 12);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => rectangle.Hight = -5);
            Assert.ThrowsException<ArgumentException>(() => rectangle.Length = -5);
        }

        [TestMethod()]
        public void Square_ValidateData_Exeption()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(4, 12);

            // Act & Assert
            Assert.AreEqual(rectangle.Length, 4);
            Assert.AreEqual(rectangle.Hight, 12);
        }

        [TestMethod()]
        public void CalculateAreaTest()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(4, 12);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculateArea(), 48);
        }

        [TestMethod()]
        public void CalculatePerimeterTest()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(4, 12);

            // Act & Assert
            Assert.AreEqual(rectangle.CalculatePerimeter(), 32);
        }
    }
}