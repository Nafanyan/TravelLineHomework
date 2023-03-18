
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

            result = Convert.ToString(doubleResult);
        }

    }
}
