
namespace Calculator.Views
{
    internal class ConsoleMessageShow : IShowMessage
    {
        public void GreetingShowMessage()
        {
            Console.Write(BasicPhrases.Greeting);
        }

        public void ResultShowMessage(string result)
        {
            Console.WriteLine($"= {result}");
        }

        public void AvailableModesShowMessage()
        {
            Console.WriteLine(BasicPhrases.AviableModes);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string? UserInput()
        {
            return Console.ReadLine();
        }

    }
}
