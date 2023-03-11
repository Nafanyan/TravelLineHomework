using SecondHomework.GeometricShapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondHomework.Interfaces;

namespace SecondHomework.GeometricShapes.Tests
{


    [TestClass()]
    public class SquareTests
    {

        [TestMethod()]
        public void Square_ValidateData_NoExeption()
        {
            // Arrange
            Square square = new Square(4);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => square.Side = -5);


        }

        [TestMethod()]
        public void Square_ValidateData_Exeption()
        {
            // Arrange
            Square square = new Square(4);

            // Act & Assert
            AssertFailedException.Equals(square.Side, 4);


        }

        [TestMethod()]
        public void CalculateAreaTest()
        {
            // Arrange
            Square square = new Square(10);

            // Act & Assert
            AssertFailedException.Equals(square.Side, 100);
        }

        [TestMethod()]
        public void CalculatePerimeterTest()
        {
            // Arrange
            Square square = new Square(10);

            // Act & Assert
            AssertFailedException.Equals(square.Side, 40);
        }


    }
}