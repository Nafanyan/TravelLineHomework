
using Calculator.ValidateData;

namespace Calculator.Models
{
    public class CalculatorRevPol : ICalculator
    {
        private Stack<double> nums;

        public override void Start(string source)
        {
            validateData = new ValidateCalculatorRevPol();
            base.Start(source);

            if (validInput) return;

            ParseString(source);
            result = Convert.ToString(nums.Pop());
        }

        public override string Result() => result;

        private void ParseString(string source)
        {
            nums = new Stack<double>();
            double supNum;

            foreach (string el in source.Split(' '))
            {
                if (el.Contains('+') || el.Contains('-') || el.Contains('/') || el.Contains('*'))
                {
                    ArithmeticOperation(Convert.ToChar(el));
                }
                if (Double.TryParse(el, out supNum)) nums.Push(supNum);
            }
        }

        private void ArithmeticOperation(char oper)
        {
            double firstNum;
            double secoNum;
            secoNum = nums.Pop();
            firstNum = nums.Pop();

            switch (oper)
            {
                case '+':
                    nums.Push(firstNum + secoNum);
                    break;

                case '-':
                    nums.Push(firstNum - secoNum);
                    break;

                case '*': nums.Push(firstNum * secoNum);
                    break;

                case '/': nums.Push(Math.Round((firstNum / secoNum), 3));
                    break;

                default:
                    break;
            }
        }

    }
}
