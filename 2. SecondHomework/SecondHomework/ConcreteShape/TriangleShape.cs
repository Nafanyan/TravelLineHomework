using SecondHomework.Interfaces;

namespace SecondHomework.ConcreteShape
{
    internal class TriangleShape : IShape
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        public TriangleShape(double firstSide, double secondSide, double thirdSide)
        {
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }

        public double CalculateArea()
        {
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - _firstSide) * (p - _secondSide) * (p - _thirdSide));
        }

        public double CalculatePerimeter()
        {
            return _firstSide + _secondSide + _thirdSide;
        }
    }
}
