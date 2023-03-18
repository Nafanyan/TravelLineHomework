
using Calculator.Exceptions;
using Calculator.ValidateData;

namespace Calculator.Models
{
    public class CalculatorRevPol : BaseCalculator
    {
        private Stack<double> stackNums;

        public override void Start(string source)
        {
            validateData = new ValidateCalculatorRevPol();
            base.Start(source);

            ParseString(source);
            result = Convert.ToString(stackNums.Pop());
        }

        private void ParseString(string source)
        {
            stackNums = new Stack<double>();
            double supNum;

            double firstNum;
            double secoNum;

            foreach (string el in source.Split(' '))
            {
                if (el.Length == 1 && BaseCalculator.Operators.Contains(Convert.ToChar(el)))
                {
                    secoNum = stackNums.Pop();
                    firstNum = stackNums.Pop();
                    supNum = ArithmeticOperation(firstNum, secoNum, Convert.ToChar(el));
                    if (Double.IsInfinity(supNum))
                    {
                        throw new CalculatorRevPolArgumentException("The result is going beyond the permissible limits");
                    }
                    stackNums.Push(supNum);
                }
                if (Double.TryParse(el, out supNum)) stackNums.Push(supNum);
            }
        }
    }
}
