
using Calculator.Exceptions;
using Calculator.ValidateData;

namespace Calculator.Models
{
    public class CalculatorSteps : BaseCalculator
    {
        
        public override void Start(string source)
        {
            validateData = new ValidateCalculatorSteps();
            base.Start(source);

            string[] splitInput = source.Split(' ');
            double doubleResult = ArithmeticOperation(Convert.ToDouble(splitInput[0]),
                Convert.ToDouble(splitInput[2]),
                Convert.ToChar(splitInput[1]));

            if (Double.IsInfinity(doubleResult))
            {
                throw new CalculationStepsArgumentException("The result is going beyond the permissible limits");
            }

            result = Convert.ToString(doubleResult);
        }

    }
}
