using SecondHomework.Interfaces;

namespace SecondHomework
{
    public abstract class Shape : IShape
    {
        protected IShape shape;
        public double CalculateArea() => shape.CalculateArea();
        public double CalculatePerimeter() => shape.CalculatePerimeter();
        protected void ValidateData(double value)
        {
            if (value < 0) throw new ArgumentException(nameof(value));
        }

    }
}
