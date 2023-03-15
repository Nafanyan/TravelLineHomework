
namespace Calculator.Models
{
    public class CalculatorSteps : IApplication
    {
        private string _result;
        public void Start(string source)
        {

            if (ValidateData(source))
            {
                _result = "Input error";
                return;
            }

            string[] elements = source.Split(' ');
            _result = ArithmeticOperation(Convert.ToDouble(elements[0]), 
                Convert.ToDouble(elements[2]), 
                Convert.ToChar(elements[1]));
        }

        public string Result() => _result;

        private string ArithmeticOperation(double firstNum, double secoNum, char oper)
        {

            switch (oper)
            {
                case '+':
                    return Convert.ToString(firstNum + secoNum);

                case '-':
                    return Convert.ToString(firstNum - secoNum);

                case '*':
                    return Convert.ToString(firstNum * secoNum);

                case '/':
                    return Convert.ToString(Math.Round((firstNum / secoNum), 3));

                default:
                    return "";
            }
        }

        private bool ValidateData(string source)
        {
            if (source == null || source == "") return true;

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
