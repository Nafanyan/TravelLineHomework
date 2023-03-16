using Calculator.Models;
using Calculator.Views;

namespace Calculator.Controller
{
    internal class MainController
    {
        private ICalculator _icalculator;
        private IMessageShow _views;
        private string? _source;
        public void Start()
        {
            _views = new ConsoleMessageShow();
            _views.GreetingMessageShow();

            _icalculator = SwapModel();

            while (_source != "exit")
            {
                _source = Console.ReadLine();

                if (_source == "swap") _icalculator = SwapModel();

                else
                {
                    if (_icalculator is CalculatorSteps) _source = InputForStepModel();

                    _icalculator.Start(_source);
                    _views.MessageShow(_icalculator.Result());
                    _views.ChangeModeMessageShow();
                }

            }
        }

        private ICalculator SwapModel()
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
