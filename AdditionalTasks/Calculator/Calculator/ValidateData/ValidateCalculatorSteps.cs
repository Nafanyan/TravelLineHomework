
using Calculator.Exceptions;
using Calculator.Models;

namespace Calculator.ValidateData
{
    internal class ValidateCalculatorSteps : IValidation
    {
        private string[] _splitInput;

        public void Validation(string source)
        {
            _splitInput = source.Split(' ');

            CheckSplitLength();

            FirstArgNullOrWhiteSpace();

            SecondArgNullOrWhiteSpace();

            ThirdArgNullOrWhiteSpace();

            FirstArgIsNumber();

            SecondArgIsOperator();

            ThirdArgIsNumber();

            DivisionByZero();
        }

        private void CheckSplitLength()
        {

            if (_splitInput.Length != 3)
            {
                throw new CalculationStepsArgumentException("The input example should have two numbers and one operator");
            }
        }

        private void FirstArgNullOrWhiteSpace()
        {

            if (_splitInput.First() == null || _splitInput.First() == "")
            {
                throw new CalculationStepsArgumentException("The first argument cannot be null or white space");
            }
        }

        private void SecondArgNullOrWhiteSpace()
        {
            if (_splitInput[1] == null || _splitInput[1] == "")
            {
                throw new CalculationStepsArgumentException("The second argument cannot be null or white space");
            }
        }

        private void ThirdArgNullOrWhiteSpace()
        {
            if (_splitInput.Last() == null || _splitInput.Last() == "")
            {
                throw new CalculationStepsArgumentException("The third argument cannot be null or white space");
            }
        }

        private void FirstArgIsNumber()
        {
            double tryParseOut;
            if (!Double.TryParse(_splitInput.First(), out tryParseOut))
            {
                throw new CalculationStepsArgumentException("The first argument must be a number");
            }
        }

        private void SecondArgIsOperator()
        {
            if (!(_splitInput[1].Length == 1 && BaseCalculator.Operators.Contains(Convert.ToChar(_splitInput[1]))))
            {
                throw new CalculationStepsArgumentException("The second argument must be a operator");
            }
        }

        private void ThirdArgIsNumber()
        {
            double tryParseOut;
            if (!Double.TryParse(_splitInput.Last(), out tryParseOut))
            {
                throw new CalculationStepsArgumentException("The third argument must be a number");
            }
        }

        private void DivisionByZero()
        {
            if (Convert.ToChar(_splitInput[1]) == '/' && _splitInput.Last() == "0")
            {
                throw new CalculationStepsArgumentException("You can't divide by zero");
            }
        }


    }
}
