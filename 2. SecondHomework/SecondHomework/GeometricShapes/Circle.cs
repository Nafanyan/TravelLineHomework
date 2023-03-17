
namespace SecondHomework.GeometricShapes
{
    public class Circle : Shape
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

        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}
