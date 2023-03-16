using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Databases;


namespace Shop.Models.Tests
{
    [TestClass()]
    public class ModelDBTests
    {

        [TestMethod()]
        public void RemoveElement_CorrectData_DiffNum()
        {
            // Arrange
            ModelDB _db = new ModelDB();
            int id = _db.DB.Products.OrderBy(p => p.CountInStock).First().Id;
            int count = _db.DB.Products.OrderBy(p => p.CountInStock).First().CountInStock;

            // Act
            _db.RemoveElement(Convert.ToString(id));

            // Assert
            Assert.AreEqual(count - 1, _db.DB.Products.Where(p => p.Id == id).First().CountInStock);

        }

        [TestMethod()]
        public void RemoveElement_CorrectData_ProtectZero()
        {
            // Arrange
            ModelDB _db = new ModelDB();

            _db.AddRequest("furniture test 1 1 test 0");
            int id = _db.DB.Products.Where(p => p.CountInStock == 0).Select(p => p.Id).First();

            // Act
            _db.RemoveElement(Convert.ToString(id));

            // Assert
            Assert.AreEqual(0, _db.DB.Products.Where(p => p.Id == id).Select(p => p.CountInStock).First());

            _db.DeleteWithID(Convert.ToString(id));

        }

        [TestMethod()]
        public void AddRequest_CorrectData_AddInDB()
        {
            // Arrange
            ModelDB _db = new ModelDB();

            // Act
            _db.AddRequest("furniture test 1 1 test 1");
            int id = _db.DB.Products.Where(p => p.NameProduct == "test").Select(p => p.Id).First();

            // Assert
            Assert.AreEqual(id, _db.DB.Products.Where(p => p.Id == id).Select(p => p.Id).First());

            _db.DeleteWithID(Convert.ToString(id));

        }
    }
}