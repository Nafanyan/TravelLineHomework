
using Microsoft.IdentityModel.Tokens;
using Shop.Databases;
using Shop.Models;
using Shop.Views;

namespace Shop.Controllers
{
    internal class MainController : IController
    {
        private IModels _models;
        private IViews _views;
        private IController _nextController;
        private string? _userInput;

        public void Start()
        {
            _views = new ViewConsole();
            _models = new ModelDB();

            while (_userInput != "exit")
            {
                _views.StartPage();
                _userInput = _views.InputUser();

                _views.Print("Введите категорию:");
                _views.Print(_models.GetTypeProduct());

                if (_userInput == "1") RemoveElement();


                if (_userInput == "2") AddElement();

            }
           
        }

        private void RemoveElement()
        {
            _userInput = _views.InputUser();
            _views.Print(_models.ReadRequest(_userInput));
            _views.Print("Выберите id объекта, который хотите купить:");
            _userInput = _views.InputUser();
            _views.Print(_models.RemoveElement(_userInput));
        }

        private void AddElement()
        {
            string result = "";
            _userInput = _views.InputUser();
            if (!_models.GetTypeProduct().Split("\n").Contains(_userInput))
            {
                _views.Print("Такой категории нет.");
                AddElement();
            }
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
}
