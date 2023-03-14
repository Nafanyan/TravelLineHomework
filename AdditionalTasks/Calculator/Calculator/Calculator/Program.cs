using Calculator.Controller;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainController controller = new Controller.MainController();
            controller.Start();

        }
    }
}