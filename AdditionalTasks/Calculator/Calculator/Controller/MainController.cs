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

            while (true)
            {
                _icalculator = SwapModel();

                if (_source == "exit") return;

                if (_icalculator is CalculatorSteps) _source = InputForStepModel();

                _icalculator.Start(_source);
                _views.MessageShow(_icalculator.Result());
            }
        }

        private ICalculator SwapModel()
        {
            _views.AvailableModesMessageShow();
            _source = _views.InputMessageShow();

            if (_source.Split(' ').Length < 3 || !_source.Contains(' ')) return new CalculatorSteps();

            else return new CalculatorRevPol();

        }

        private string InputForStepModel()
        {
            string operat = _views.InputMessageShow();
            string operand = _views.InputMessageShow();
            if (_source.Length > 1) _source = _source.Remove(_source.Length - 1);
            return $"{_source} {operat} {operand}";
        }
    }
}
