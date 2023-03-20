
using Shop.Database;
using Shop.ExceptionHandling.AddProductException;
using Shop.Repository;
using Shop.Views;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    internal class AddProductModel : IProductModel
    {
        private Product _product;
        private ValidateAddProduct _validate;
        public Product Result { get { return _product; } }

        public AddProductModel()
        {
            _validate = new ValidateAddProduct();
        }

        public void Start(IRepository<Product> db, IViews views)
        {
            string userInput = _validate.NullOrWhiteSpace(views.UserInput());
            _validate.CheckCategory(db, userInput);

            _product = new Product();
            _product.TypeProduct = userInput;

            views.MessageShow(BasicPhrases.inputName);
            userInput = views.UserInput();
            _product.NameProduct = _validate.NullOrWhiteSpace(userInput);

            views.MessageShow(BasicPhrases.inputWeight);
            userInput = views.UserInput();
            _product.WeightProduct = (float)_validate.WeightCheck(userInput);

            views.MessageShow(BasicPhrases.inputPrice);
            userInput = views.UserInput();
            _product.Price = _validate.PriceCheck(userInput);

            views.MessageShow(BasicPhrases.inputDescription);
            userInput = views.UserInput();
            _product.DescriptionProduct = _validate.NullOrWhiteSpace(userInput);

            views.MessageShow(BasicPhrases.inputCount);
            userInput = views.UserInput();
            _product.CountInStock = _validate.CountCheck(userInput);

            db.Create(_product);
            db.Save();
        }
    }
}
