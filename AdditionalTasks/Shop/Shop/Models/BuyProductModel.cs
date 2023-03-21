
using Shop.Database;
using Shop.ExceptionHandling.BuyProductException;
using Shop.Repository;
using Shop.Views;

namespace Shop.Models
{
    internal class BuyProductModel : BaseProductModel
    {
        private ValidateBuyProduct _validate;
        public BuyProductModel(IRepository<Product> db, IViews views) : base(db, views)
        {
            _validate = new ValidateBuyProduct();
        }


        public override void Start()
        {
            string userInput = views.UserInput();
            SameCategoryProductView(userInput);

            userInput = InputId();

            product = db.GetProduct(Convert.ToInt32(userInput));
            _validate.CheckCount(product);

            product.CountInStock--;
            db.Update(product);
            db.Save();
        }

        private void SameCategoryProductView(string userInput)
        {
            _validate.CheckCategory(db, userInput);

            foreach (Product product in db.GetAllProducts().Where(p => p.TypeProduct == userInput))
            {
                views.MessageShow(product.ToString());
            }
        }

        private string InputId()
        {
            views.MessageShow(BasicPhrases.inputID);
            string userInput = views.UserInput();
            _validate.CheckID(db, userInput);
            return userInput;
        }
    }
}
