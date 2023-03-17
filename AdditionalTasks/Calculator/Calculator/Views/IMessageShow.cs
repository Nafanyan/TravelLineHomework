
namespace Calculator.Views
{
    internal interface IMessageShow
    {
        public void GreetingMessageShow();
        public void MessageShow(string source);
        public void AvailableModesMessageShow();
        public string? InputMessageShow();
    }
}
