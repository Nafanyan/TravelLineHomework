
using SecondHomework.Ecxeptions;
using SecondHomework.Interfaces;

namespace SecondHomework.GeometricShapes
{
    public class Circle : IShape
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                ValidateData(value);
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }
        private void ValidateData(double value)
        {
            if (value < 0) throw new NegativeArgumentException("The circle radius parameter cannot be negative", value.ToString());
        }
    }
}
