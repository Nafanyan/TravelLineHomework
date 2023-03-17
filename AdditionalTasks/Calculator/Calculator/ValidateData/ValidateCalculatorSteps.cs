
namespace Calculator.ValidateData
{
    internal class ValidateCalculatorSteps : IValidateData
    {
        public bool Validate(string source)
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
