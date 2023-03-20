using Shop.Database;
using Shop.ExceptionHandling.AddProductException;
using Shop.ExceptionHandling.BuyProductException;
using Shop.ExceptionHandling.HomeControllerException;
using Shop.Models;
using Shop.Repository;
using Shop.Views;

namespace Shop.Controllers
{
    internal class HomeController
    {
        public string DBTXT;

        private readonly IRepository<Product> _db;
        private readonly IViews _views;
        private readonly ValidateHomeController _validate;
        private string? _userInput;
        public HomeController()
        {
            _views = new ViewConsole();
            _db = new SQLProductRepository();
            _validate = new ValidateHomeController(new List<string> {"1", "2", "exit" });
            //DBTXT = "C:\\Users\\01112\\Documents\\CShark\\TravelLineHomework\\AdditionalTasks\\Shop\\Shop\\db.txt";
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    _views.StartPage();
                    _userInput = _validate.CheckModuleSelection(_views.UserInput());

                    if (_userInput == "exit") return;

                    _views.MessageShow("Выберите категорию из имеющихся:");
                    _views.MessageShow(GetCurrentCategories());

                    if (_userInput == "1")
                    {
                        ModelSelection(new BuyProductModel(), _views);
                    }

                    if (_userInput == "2")
                    {
                        ModelSelection(new AddProductModel(), _views);
                    }
                    AllProductView();
                    _views.MessageShow("");
                }

                catch (BuyProductArgumentException arg)
                {
                    _views.MessageShow($"Ошибка при попытке совершения покупки: {arg.Message}.");
                }
                catch (AddProductArgumentException arg)
                {
                    _views.MessageShow($"Ошибка при попытке добавления продукт в каталог: {arg.Message}.");
                }
                catch (HomeControllerException ex)
                {
                    _views.MessageShow($"Ошибка при попытке выбора режима работы: {ex.Message}.");
                }

                _views.MessageShow("");
            }
        }
        private void ModelSelection(IProductModel model, IViews view)
        {
            model.Start(_db, _views);
            _views.MessageShow($"Состояние продукта: {model.Result.ToString()}");
        }

        private string GetCurrentCategories()
        {
            string result = "";

            foreach (string type in _db.GetAllProducts().Select(p => p.TypeProduct))
            {
                if (!result.Contains(type)) result += $"- {type}\n";
            }
            return result;
        }

        private void AllProductView()
        {
            _views.MessageShow("\nКаталог на данный момент:");
            foreach (Product product in _db.GetAllProducts())
            {
                _views.MessageShow(product.ToString());
            }
        }

    }

}
