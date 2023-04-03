
using Shop.Database;
using Shop.Repository;

namespace Shop.ExceptionHandling.AddProductException
{
    internal class ValidateAddProduct
    {
        public string NullOrWhiteSpace(string source)
        {
            if (source == null || source == "")
            {
                throw new AddProductArgumentException("Входное значение не может быть пустым");
            }
            return source;
        }

        public void CheckCategory(IRepository<Product> db, string category)
        {
            NullOrWhiteSpace(category);

            if (!db.GetAllProducts().Any(product => product.TypeProduct == category))
            {
                throw new AddProductArgumentException("Указанная категория не существует в каталоге");
            }
        }

        public double WeightCheck(string weightStr)
        {
            double weight = 0;

            weightStr = NullOrWhiteSpace(weightStr);

            if (! Double.TryParse(weightStr, out weight))
            {
                throw new AddProductArgumentException("Вес продукта должен быть введен цифрах");
            }

            if (Double.IsInfinity(weight))
            {
                throw new AddProductArgumentException("Слишком большое значение для веса");
            }

            return weight;
        }

        public decimal PriceCheck(string priceStr)
        {
            decimal price = 0;

            priceStr = NullOrWhiteSpace(priceStr);

            if (!Decimal.TryParse(priceStr, out price))
            {
                throw new AddProductArgumentException("Цена продукта должна быть введена цифрах");
            }

            if (Double.IsInfinity(Convert.ToDouble(price)))
            {
                throw new AddProductArgumentException("Слишком большое значение для цены");
            }

            return price;
        }

        public int CountCheck(string countStr)
        {
            int count = 0;

            countStr = NullOrWhiteSpace(countStr);

            if (!int.TryParse(countStr, out count))
            {
                throw new AddProductArgumentException("Количество продукта должна быть введена цифрах");
            }

            if (count <= 0)
            {
                throw new AddProductArgumentException("Количество продукта должно быть больше нуля");
            }

            return count;
        }
    }
}
