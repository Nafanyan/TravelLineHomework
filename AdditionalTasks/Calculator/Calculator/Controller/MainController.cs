using Calculator.Exceptions;
using Calculator.Models;
using Calculator.Views;

namespace Calculator.Controller
{
    internal class MainController
    {
        private BaseCalculator _baseCalculator;
        private readonly IShowMessage _views;
        private string? _source;
        public MainController()
        {
            _views = new ConsoleMessageShow();
        }

        public void Start()
        {
            _views.GreetingShowMessage();
            while (true)
            {
                try
                {
                    _baseCalculator = SwapModel();

                    if (_source == "exit") return;

                    if (_baseCalculator is CalculatorSteps) _source = InputForStepModel();

                    _baseCalculator.Start(_source);
                    _views.ResultShowMessage(_baseCalculator.Result);
                }

                catch (CalculatorRevPolArgumentException arg)
                {
                    _views.ShowMessage($"Error in Polish notation mode: {arg.Message}.\n");
                }
                catch (CalculationStepsArgumentException args)
                {
                    _views.ShowMessage($"Error in step-by-step mode: {args.Message}.\n");
                }

            }

        }

        private Models.BaseCalculator SwapModel()
        {
            _views.AvailableModesShowMessage();
            _source = _views.UserInput();

            if (_source.Split(' ').Length < 3 || !_source.Contains(' '))
            {
                _views.ShowMessage("Step-by-step mode is selected");
                _views.ShowMessage(_source);
                return new CalculatorSteps();
            }
            else
            {
                _views.ShowMessage("The Polish notation mode is selected");
                return new CalculatorRevPol();
            }

        }

        private string InputForStepModel()
        {
            string operat = _views.UserInput();
            string operand = _views.UserInput();
            return $"{_source} {operat} {operand}";
        }
    }
}
