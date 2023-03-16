using Shop.Models;
using Shop.Views;

namespace Shop.Controllers.ActionControllers
{
    internal class RemoveElementController : IController
    {
        private IModels _models;
        private IViews _views;
        private string? _userInput;
        public RemoveElementController(IModels model, IViews views)
        {
            _models = model;
            _views = views;
        }

        public void Start()
        {
            _userInput = _views.InputUser();
            _views.Print(_models.ReadRequest(_userInput));

            if (!_models.GetTypeProduct().Split("\n").Contains(_userInput))
            {
                _views.Print("Такой категории нет.");
                Start();
            }
            else
            {
                _views.Print("Выберите id объекта, который хотите купить:");
                _userInput = _views.InputUser();
                _views.Print(_models.RemoveElement(_userInput));
            }
        }

        public void NextController(IController controller) { }
    }
}
