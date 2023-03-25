
namespace SecondHomework.Ecxeptions
{
    internal class NegativeArgumentException : ArgumentException
    {
        public string Parameter { get; }
        public NegativeArgumentException(string message, string param) : base(message) 
        {
            Parameter = param;
        }
    }
}
