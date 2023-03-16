
using Calculator.ValidateData;

namespace Calculator.Models
{
    public class CalculatorSteps : ICalculator
    {
        
        public override void Start(string source)
        {
            validateData = new ValidateCalculatorSteps();
            base.Start(source);

            if (validInput) return;

            string[] elements = source.Split(' ');
            result = ArithmeticOperation(Convert.ToDouble(elements[0]), 
                Convert.ToDouble(elements[2]), 
                Convert.ToChar(elements[1]));
        }

        public override string Result() => result;

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

    }
}
