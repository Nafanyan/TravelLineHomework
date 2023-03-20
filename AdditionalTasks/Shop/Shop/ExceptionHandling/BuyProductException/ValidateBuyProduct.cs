
using Shop.Database;
using Shop.Repository;


namespace Shop.ExceptionHandling.BuyProductException
{
    internal class ValidateBuyProduct
    {
        public void NullOrWhiteSpace(string source)
        {
            if (source == null || source == "")
            {
                throw new BuyProductArgumentException("Входное значение не может быть пустым");
            }
        }
        public void CheckCount(Product product)
        {
            if (product.CountInStock <= 0)
            {
                throw new BuyProductArgumentException("Указанного продукта нет на складе");
            }
        }

        public void CheckCategory(IRepository<Product> db, string category)
        {
            NullOrWhiteSpace(category);

            if (!db.GetAllProducts().Any(product => product.TypeProduct == category))
            {
                throw new BuyProductArgumentException("Указанная категория не существует в каталоге");
            }
        }

        public void CheckID(IRepository<Product> db, string idStr)
        {
            int id = 0;
            NullOrWhiteSpace(idStr);

            if (!int.TryParse(idStr, out id))
            {
                throw new BuyProductArgumentException("ID продукта должен быть введен цифрах");
            }

            if (db.GetProduct(Convert.ToInt32(idStr)) == null)
            {
                throw new BuyProductArgumentException("Продукта с указанным id не существует в каталоге");
            }
        }
    }
}
