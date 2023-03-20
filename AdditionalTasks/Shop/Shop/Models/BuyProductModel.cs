
using Shop.Database;
using Shop.ExceptionHandling.BuyProductException;
using Shop.Repository;
using Shop.Views;

namespace Shop.Models
{
    internal class BuyProductModel : IProductModel
    {
        public Product Result { get { return _product; } }

        private Product _product;
        private ValidateBuyProduct _validate;
        public BuyProductModel()
        {
            _validate = new ValidateBuyProduct();
        }

        public void Start(IRepository<Product> db, IViews views)
        {
            string userInput = views.UserInput();
            _validate.CheckCategory(db, userInput);

            foreach (Product product in db.GetAllProducts().Where(p => p.TypeProduct == userInput))
            {
                views.MessageShow(product.ToString());
            }

            views.MessageShow(BasicPhrases.inputID);
            userInput = views.UserInput();
            _validate.CheckID(db, userInput);

            _product = db.GetProduct(Convert.ToInt32(userInput));
            _validate.CheckCount(_product);

            _product.CountInStock--;
            db.Update(_product);
            db.Save();
        }
    }
}
