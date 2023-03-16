
namespace Calculator.Views
{
    internal class ConsoleMessageShow : IMessageShow
    {
        private BasicPhrases _basicPhrases;
        public ConsoleMessageShow()
        {
            _basicPhrases = new BasicPhrases();
        }
        public void MessageShow(string source)
        {
            Console.Write($"= {source}");
            Console.WriteLine();
        }

        public void GreetingMessageShow()
        {
            Console.Write(_basicPhrases.Greeting);
        }

        public void AvailableModesMessageShow()
        {
            Console.WriteLine(_basicPhrases.AviableModes);
        }

        public string? InputMessageShow()
        {
            return Console.ReadLine();
        }
    }
}
