using Shop.Controllers.ActionControllers;
using Shop.Databases;
using Shop.Models;
using Shop.Views;

namespace Shop.Controllers
{
    internal class MainController : IController
    {
        private IModels _models;
        private IViews _views;
        private string? _userInput;
        public string dbTXT;

        public MainController()
        {
            _views = new ViewConsole();
            _models = new ModelDB();
            dbTXT = "C:\\Users\\01112\\Documents\\CShark\\TravelLineHomework\\AdditionalTasks\\Shop\\Shop\\db.txt";
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

            _models.WriteFile(dbTXT);
            Start();
        }
        public void NextController(IController controller)
        {
            controller.Start();
        }
    }
}
