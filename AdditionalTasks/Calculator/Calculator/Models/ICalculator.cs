
using Calculator.ValidateData;

namespace Calculator.Models
{
    public abstract class ICalculator
    {
        protected string? result;
        protected IValidateData validateData;
        protected bool validInput;

        public virtual void Start(string source)
        {
            validInput = false;
            if (validateData.Validate(source))
            {
                result = "Input error";
                validInput = true;
            }
        }
        public abstract string Result();


    }
}
