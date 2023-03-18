
using Calculator.Exceptions;
using Calculator.Models;

namespace Calculator.ValidateData
{
    internal class ValidateCalculatorRevPol : IValidation
    {
        private int _countOper;
        private int _countNum;
        private string _unidentifiedChar;
        private string[] _splitInput;

        public void Validation(string source)
        {
            _splitInput = source.Split(' ');

            NullOrWhiteSpace(source);

            NumOfMathElements();

            ContentOfExtraSpaces();

            CountingCharacters();

            ChecExtraCharacters();

            ComparisonOperatorsWithNumbers();

            IsNotPolishNotation();

            DivisionByZero();
        }

        private void NullOrWhiteSpace(string source)
        {
            if (source == null || source == "")
            {
                throw new CalculatorRevPolArgumentException("The input example cannot be null or white space");
            }
        }

        private void NumOfMathElements()
        {
            if (_splitInput.Length < 3)
            {
                throw new CalculatorRevPolArgumentException("The input example cannot contain less than three mathematical elements");
            }
        }

        private void ContentOfExtraSpaces()
        {
            if (_splitInput.Contains(""))
            {
                throw new CalculatorRevPolArgumentException("The input example has an extra space");
            }
        }

        private void CountingCharacters()
        {
            _countOper = 0;
            _countNum = 0;
            _unidentifiedChar = "";
            double tryParseOut;

            foreach (string el in _splitInput)
            {
                if (el.Length == 1 && BaseCalculator.Operators.Contains(Convert.ToChar(el)))
                {
                    _countOper++;
                }

                else if (Double.TryParse(el, out tryParseOut))
                {
                    _countNum++;
                }

                else
                {
                    _unidentifiedChar += $"{el} ";
                }
            }
        }

        private void ChecExtraCharacters()
        {
            if (_countNum + _countOper != _splitInput.Length)
            {
                throw new CalculatorRevPolArgumentException($"The input example cannot contain the following characters: {_unidentifiedChar}");
            }
        }
        private void ComparisonOperatorsWithNumbers()
        {
            if (_countNum - 1 != _countOper)
            {
                throw new CalculatorRevPolArgumentException("The input example should have the number of operands one more than the number of operators");
            }
        }

        private void IsNotPolishNotation()
        {
            _countOper = 0;
            _countNum = 0;
            double tryParseOut;

            foreach (string el in _splitInput)
            {

                if (el.Length == 1 && BaseCalculator.Operators.Contains(Convert.ToChar(el)))
                {
                    _countOper++;
                }

                if (_countOper == _countNum && Double.TryParse(el, out tryParseOut))
                {
                    if (_countNum != 0 && _countOper != 0)
                    {
                        throw new CalculatorRevPolArgumentException("The input example is not Polish notation");
                    }
                }

                if (Double.TryParse(el, out tryParseOut))
                {
                    _countNum++;
                }

            }

        }

        private void DivisionByZero()
        {
            double tryParseOut;
            string operat = "";

            foreach (string el in _splitInput)
            {

                if (el.Length == 1 && BaseCalculator.Operators.Contains(Convert.ToChar(el)))
                {
                    operat = el;
                }

                if (Double.TryParse(el, out tryParseOut)) { }

                if (tryParseOut == 0 && operat == "/")
                {
                    throw new CalculatorRevPolArgumentException("You can't divide by zero");
                }

            }
        }
    }
}
