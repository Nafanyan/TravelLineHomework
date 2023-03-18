
using SecondHomework.Ecxeptions;
using SecondHomework.Interfaces;

namespace SecondHomework.GeometricShapes
{
    public class Square : IShape
    {
        private double _side;
        public double Side
        {
            get { return _side; }
            set 
            {
                ValidateData(value); 
                _side = value; 
            }
        }
        public Square(double side)
        {
            Side = side;
        }

        public double CalculateArea()
        {
            return _side * _side;
        }

        public double CalculatePerimeter()
        {
            return _side * 4;
        }

        private void ValidateData(double value)
        {
            if (value < 0) throw new NegativeArgumentException("The square length parameter cannot be negative", value.ToString());
        }

    }
}
