using Shop.Controllers.ActionControllers;
using Shop.Models;
using Shop.Views;

namespace Shop.Controllers
{
    internal class MainController : IController
    {
        private IModels _models;
        private IViews _views;
        private string? _userInput;

        public MainController()
        {
            _views = new ViewConsole();
            _models = new ModelDB();
        }
        public void Start()
        {
            _views.StartPage();
            _userInput = _views.InputUser();

            if (_userInput == "exit") return;

            _views.Print("Введите категорию:");
            _views.Print(_models.GetTypeProduct());

            if (_userInput == "1") NextController(new RemoveElementController(_models, _views));

            if (_userInput == "2") NextController(new AddElementController(_models, _views));

            Start();
        }
        public void NextController(IController controller)
        {
            controller.Start();
        }
    }
}
