using SecondHomework.Interfaces;
using SecondHomework.GeometricShapes;
using SecondHomework.Ecxeptions;

namespace SecondHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IShape shape = new Triangle(1, 12, 10);
                Console.WriteLine($"P = {shape.CalculatePerimeter()}, S = {shape.CalculateArea()}");
            }
            catch (NegativeArgumentException argument)
            {
                Console.WriteLine($"Incorrect argument parameter: {argument.Message} {argument.Parameter}");
            }
            catch (SidesTriangleArgumentException argument)
            {
                Console.WriteLine($"Incorrect argument parameter: {argument.Message} {argument.FirstSumSides} + {argument.SecondSumSides} < {argument.Side}");
            }
        }
    }
}