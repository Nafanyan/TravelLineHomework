
namespace Calculator.Views
{
    internal class BasicPhrases
    {
        public string Greeting
        {
            get
            {
                return "\"Hi! This is a simple arithmetic calculator. \" +\r\n " +
                    "\"If you want to finish, write \\\"exit\\\" \\n\"";
            }
        }

        public string ChangeMode
        {
            get
            {
                return "To change the model, enter swap: ";
            }
        }

        public string AviableModes
        {
            get
            {
                return "For reverse Polish notation press 1, for step by step example press 2:";
            }
        }
    }
}
