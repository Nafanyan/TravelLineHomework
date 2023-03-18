
using Calculator.ValidateData;
using System.Collections.Immutable;

namespace Calculator.Models
{
    public abstract class BaseCalculator
    {
        static public ImmutableArray<char> Operators = ImmutableArray.Create('+', '-', '*', '/');

        protected string result;
        protected IValidation validateData;

        public string Result
        {
            get { return result; }
        }

        public virtual void Start(string source)
        {
            result = "";
            validateData.Validation(source);
        }

        protected double ArithmeticOperation(double firstNum, double secoNum, char oper)
        {

            switch (oper)
            {
                case '+':
                    return firstNum + secoNum;

                case '-':
                    return firstNum - secoNum;

                case '*':
                    return firstNum * secoNum;

                case '/':
                    return Math.Round((firstNum / secoNum), 3);

                default:
                    return 0.0; 
            }
        }

    }

}
