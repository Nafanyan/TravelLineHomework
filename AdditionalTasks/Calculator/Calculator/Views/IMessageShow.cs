
namespace Calculator.Views
{
    internal interface IShowMessage
    {
        public void GreetingShowMessage();
        public void ResultShowMessage(string result);
        public void AvailableModesShowMessage();
        public void ShowMessage(string message);
        public string? UserInput();
    }
}
