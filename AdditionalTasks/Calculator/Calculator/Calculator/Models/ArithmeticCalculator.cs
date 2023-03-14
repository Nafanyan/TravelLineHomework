
using System.Numerics;

namespace Calculator.Models
{
    public class ArithmeticCalculator : IApplication
    {
        private Stack<double> nums;

        private string? _result;

        public void Start(string source)
        {
            if (ValidateData(source))
            {
                _result = "Input error";
                return;
            }

            ParseString(source);
            _result = Convert.ToString(nums.Pop());
        }
        public string Result() => _result;

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

        private bool ValidateData(string source)
        {
            if (source == null || source == "") return  true;

            if (source.Split(' ').Length < 3) return true;

            int countOper = 0;
            int countNum = 0;
            double supNum;

            foreach (string el in source.Split(' '))
            {
                if (el == "+" || el == "-" || el == "/" || el == "*")
                {
                    countOper++;
                }
                if (Double.TryParse(el, out supNum)) countNum++;
            }

            if (countNum - 1 != countOper || countNum + countOper != source.Split(' ').Length) return true;

            return false;

        }



    }
}
