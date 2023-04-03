
using Shop.Database;
using Shop.ExceptionHandling.AddProductException;
using Shop.Repository;
using Shop.Views;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    internal class AddProductModel : BaseProductModel
    {
        private Product _product;
        private ValidateAddProduct _validate;

        public Product Result { get { return _product; } }

        public AddProductModel(IRepository<Product> db, IViews views) : base(db, views)
        {
            _validate = new ValidateAddProduct();
        }

        public override void Start()
        {
            _product = new Product();

            _product.TypeProduct = AddCategory();

            _product.NameProduct = AddName();

            _product.WeightProduct = AddWeight();

            _product.Price = AddPrice();

            _product.DescriptionProduct = AddDescription();

            _product.CountInStock = AddCount();

            db.Create(_product);
            db.Save();
        }

        private string AddCategory()
        {
            string userInput = views.UserInput();
            _validate.CheckCategory(db, userInput);
            return userInput;
        }
        private string AddName()
        {
            views.MessageShow(BasicPhrases.inputName);
            string userInput = views.UserInput();
            return _validate.NullOrWhiteSpace(userInput);
        }
        private float AddWeight()
        {
            views.MessageShow(BasicPhrases.inputWeight);
            string userInput = views.UserInput();
            return (float)_validate.WeightCheck(userInput);
        }

        private decimal AddPrice()
        {
            views.MessageShow(BasicPhrases.inputPrice);
            string userInput = views.UserInput();
            return _validate.PriceCheck(userInput);
        }

        private string AddDescription()
        {
            views.MessageShow(BasicPhrases.inputDescription);
            string userInput = views.UserInput();
            return _validate.NullOrWhiteSpace(userInput);
        }

        private int AddCount()
        {
            views.MessageShow(BasicPhrases.inputCount);
            string userInput = views.UserInput();
            return _validate.CountCheck(userInput);
        }
    }
}
