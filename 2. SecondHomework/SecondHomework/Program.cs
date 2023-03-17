using SecondHomework.Interfaces;
using SecondHomework.GeometricShapes;

namespace SecondHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Triangle(3, 9, 10);
            Console.WriteLine($"P = {shape.CalculatePerimeter()}, S = {shape.CalculateArea()}");
        }
    }
}