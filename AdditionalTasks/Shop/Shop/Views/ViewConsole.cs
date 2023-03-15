
namespace Shop.Views
{
    internal class ViewConsole : IViews
    {
        public void StartPage()
        {
            Console.WriteLine("Добро пожаловать в магазин!" +
                "\nНеобходимо выбрать следующее действие: 1 - купить товар\n2 - добавить товар");
        }

        public void Print(string print)
        {
            Console.WriteLine(print);
        }

        public string? InputUser()
        {
            return Console.ReadLine();
        }
    }
}
