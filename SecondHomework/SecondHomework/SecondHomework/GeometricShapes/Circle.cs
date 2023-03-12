using SecondHomework.ConcreteShape;

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
            shape = new CircleShape(radius);
        }
    }
}
