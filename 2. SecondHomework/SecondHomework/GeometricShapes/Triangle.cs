
using SecondHomework.Ecxeptions;
using SecondHomework.Interfaces;

namespace SecondHomework.GeometricShapes
{
    public class Triangle : IShape
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        public double FirstSide
        {
            get { return _firstSide; }
            set
            {
                ValidateData(value);
                _firstSide = value;
            }
        }
        public double SecondSide
        {
            get { return _secondSide; }
            set
            {
                ValidateData(value);
                _secondSide = value;
            }
        }
        public double ThirdSide
        {
            get { return _thirdSide; }
            set
            {
                ValidateData(value);
                _thirdSide = value;
            }
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            ValidateSides(firstSide, secondSide, thirdSide);
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
        private void ValidateData(double value)
        {
            if (value < 0) throw new NegativeArgumentException("The triangle length parameter cannot be negative", value.ToString());
        }

        private void ValidateSides(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide + secondSide < thirdSide)
            {
                throw new SidesTriangleArgumentException("The sum of two sides of a triangle cannot be less than the value of one side",
                    firstSide.ToString(), secondSide.ToString(), thirdSide.ToString());
            }

            if (secondSide + thirdSide < firstSide)
            {
                throw new SidesTriangleArgumentException("The sum of two sides of a triangle cannot be less than the value of one side",
                    secondSide.ToString(), thirdSide.ToString(), firstSide.ToString());
            }

            if (firstSide + thirdSide < secondSide)
            {
                throw new SidesTriangleArgumentException("The sum of two sides of a triangle cannot be less than the value of one side",
                    firstSide.ToString(), thirdSide.ToString(), secondSide.ToString());
            }
        }
    }
}
