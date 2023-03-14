
using Calculator.Models;
using Calculator.Views;

namespace Calculator.Controller
{
    internal class MainController
    {
        private IApplication _application;
        private IViews _views;
        private string? _source;
        public void Start()
        {
            _source = "defolt";
            _application = new ArithmeticCalculator();
            _views = new ConsoleView();

            _views.StartPrint();
            while (_source != "exit")
            {
                _source = Console.ReadLine();
                _application.Start(_source);
                _views.PrintData(_application.Result());
            }

        }
    }
}
