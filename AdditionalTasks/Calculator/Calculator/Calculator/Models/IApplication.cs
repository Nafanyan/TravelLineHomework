
namespace Calculator.Models
{
    internal interface IApplication
    {
        public void Start(string source);
        public string Result();
    }
}
