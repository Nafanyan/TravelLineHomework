
namespace Shop.Views
{
    internal class ViewConsole : IViews
    {
        public void StartPage()
        {
            Console.WriteLine("Добро пожаловать в магазин!" +
                "\nНеобходимо выбрать следующее действие:\n1 - купить товар, 2 - добавить товар. Для выхода введите \"exit\"");
        }

        public void MessageShow(string print)
        {
            Console.WriteLine(print);
        }

        public string? UserInput()
        {
            return Console.ReadLine();
        }
    }
}
