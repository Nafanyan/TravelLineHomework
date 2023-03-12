
using SecondHomework.Interfaces;

namespace SecondHomework.ConcreteShape
{
    internal class RectangleShape : IShape
    {
        private double _length;
        private double _hight;

        public RectangleShape(double length, double hight)
        {
            _length = length;
            _hight = hight;
        }

        public double CalculateArea()
        {
            return _length * _hight;
        }

        public double CalculatePerimeter()
        {
            return _length * 2 + _hight * 2;
        }
    }
}
