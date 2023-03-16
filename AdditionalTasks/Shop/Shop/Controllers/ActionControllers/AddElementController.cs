using Shop.Models;
using Shop.Views;

namespace Shop.Controllers.ActionControllers
{
    internal class AddElementController : IController
    {
        private IModels _models;
        private IViews _views;
        private string? _userInput;
        public AddElementController(IModels model, IViews views)
        {
            _models = model;
            _views = views;
        }

        public void Start()
        {
            string result = "";
            _userInput = _views.InputUser();

            if (!_models.GetTypeProduct().Split("\n").Contains(_userInput))
            {
                _views.Print("Такой категории нет.");
                Start();
            }
            else
            {
                result += _userInput + " ";

                _views.Print("Название товара:");
                _userInput = _views.InputUser();
                result += _userInput + " ";

                _views.Print("Вес товара:");
                _userInput = _views.InputUser();
                result += _userInput + " ";

                _views.Print("Цена товара:");
                _userInput = _views.InputUser();
                result += _userInput + " ";

                _views.Print("Описание товара:");
                _userInput = _views.InputUser();
                result += _userInput + " ";

                _views.Print("Количество на складе товара:");
                _userInput = _views.InputUser();
                result += _userInput + " ";

                _views.Print(_models.AddRequest(result));
            }

        }

        public void NextController(IController controller) { }
    }
}
