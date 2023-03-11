using SecondHomework.Interfaces;
using SecondHomework.GeometricShapes;

namespace SecondHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape square = new Triangle(3, 9, 10);
            Console.WriteLine($"P = {square.CalculatePerimeter()}, S = {square.CalculateArea()}");
        }
    }
}