
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
            this.Length = length;
            this.Hight = hight;
        }
        public override double CalculateArea()
        {
            return _length * _hight;
        }

        public override double CalculatePerimeter()
        {
            return _length * 2 + _hight * 2;
        }
    }
}
