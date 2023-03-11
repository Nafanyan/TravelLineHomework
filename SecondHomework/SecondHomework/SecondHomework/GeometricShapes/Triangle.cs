
namespace SecondHomework.GeometricShapes
{
    public class Triangle : Shape
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
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
            this.ThirdSide = thirdSide;
            ValidateSides();
        }
        public override double CalculateArea()
        {
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - _firstSide) * (p - _secondSide) * (p - _thirdSide));
        }
        public override double CalculatePerimeter()
        {
            return _firstSide + _secondSide + _thirdSide;
        }

        private void ValidateSides()
        {
            if (! (_firstSide + _secondSide > _thirdSide)) throw new ArgumentException();
            if (!(_secondSide + _thirdSide > _firstSide)) throw new ArgumentException();
            if (!(_firstSide + _thirdSide > _secondSide)) throw new ArgumentException();
        }

    }
}
