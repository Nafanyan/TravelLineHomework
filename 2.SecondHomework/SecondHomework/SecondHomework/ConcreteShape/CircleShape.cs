
using SecondHomework.Interfaces;

namespace SecondHomework.ConcreteShape
{
    internal class CircleShape : IShape
    {
        private double _radius;

        public CircleShape(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}
