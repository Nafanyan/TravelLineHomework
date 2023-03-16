using Calculator.Models;
using Calculator.Views;

namespace Calculator.Controller
{
    internal class MainController
    {
        private IApplication _application;
        private IMessageShow _views;
        private string? _source;
        public void Start()
        {
            _views = new ConsoleMessageShow();
            _views.GreetingMessageShow();

            _application = SwapModel();

            while (_source != "exit")
            {
                _source = Console.ReadLine();

                if (_source == "swap") _application = SwapModel();

                else
                {
                    if (_application is CalculatorSteps) _source = InputForStepModel();

                    _application.Start(_source);
                    _views.MessageShow(_application.Result());
                    _views.ChangeModeMessageShow();
                }

            }
        }

        private IApplication SwapModel()
        {
            _views.AvailableModesMessageShow();
            string options = Console.ReadLine();
            if (options == "1") return new CalculatorRevPol();
 
            if (options == "2") return new CalculatorSteps();

            return SwapModel();
        }

        private string InputForStepModel()
        {
            string operat = Console.ReadLine();
            string operand = Console.ReadLine();
            return $"{_source} {operat} {operand}";
        }
    }
}
