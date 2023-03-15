using Shop.Controllers;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IController controller = new MainController();
            controller.Start();
        }
    }
}