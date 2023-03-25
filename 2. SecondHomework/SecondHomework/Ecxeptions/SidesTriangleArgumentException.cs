
namespace SecondHomework.Ecxeptions
{
    internal class SidesTriangleArgumentException : ArgumentException
    {
        public string Side { get; }
        public string FirstSumSides { get; }
        public string SecondSumSides { get; }
        public SidesTriangleArgumentException(string message, string firstSumSides, string secondSumSides, string side) : base (message) 
        {
            FirstSumSides = firstSumSides;
            SecondSumSides = secondSumSides;
            Side = side;
        }
    }
}
