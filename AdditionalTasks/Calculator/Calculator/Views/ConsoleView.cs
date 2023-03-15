
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
                "If you want to finish, write \"exit\" \n");
        }

        public void EndPrint()
        {
            Console.Write("To change the model, enter swap: ");
        }

        public void PrintOptions()
        {
            Console.WriteLine("For reverse Polish notation press 1, for step by step example press 2:");
        }
    }
}
