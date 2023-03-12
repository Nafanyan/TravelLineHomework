using SecondHomework.ConcreteShape;

namespace SecondHomework.GeometricShapes
{
    public class Rectangle : Shape
    {
        private double _length;
        private double _hight;

        public double Length
        {
            get { return _length; }
            set 
            {
                ValidateData(value);
                _length = value;
            }
        }
        public double Hight
        {
            get { return _hight; }
            set
            {
                ValidateData(value);
                _hight = value;
            }
        }

        public Rectangle(double length, double hight)
        {
            Length = length;
            Hight = hight;
            shape = new RectangleShape(length, hight);
        }
    }
}
