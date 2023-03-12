
using SecondHomework.Interfaces;

namespace SecondHomework.ConcreteShape
{
    internal class SquareShape : IShape
    {
        private double _side;
        
        public SquareShape(double side)
        {
            _side = side;
        }
        public double CalculateArea()
        {
            return _side * _side;
        }

        public double CalculatePerimeter()
        {
            return _side * 4;
        }
    }
}
