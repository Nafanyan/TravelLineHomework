
namespace Calculator.Views
{
    internal class ConsoleView : IViews
    {
        public void PrintData(string source)
        {
            Console.Write($"= {source}");
            Console.WriteLine();
        }

        public void StartPrint()
        {
            Console.Write("Hi! This is a simple arithmetic calculator. " +
                "If you want to finish, write \"exit\" \n" + "Please enter examples in reverse Polish notation: ");
        }
    }
}
