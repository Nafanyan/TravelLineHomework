using SecondHomework.Interfaces;

namespace SecondHomework
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        protected void ValidateData(double value)
        {
            if (value < 0) throw new ArgumentException(nameof(value));
        }

    }
}
