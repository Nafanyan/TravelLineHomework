using Shop.Controllers;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeController controller = new HomeController();
            controller.Start();
        }
    }
}