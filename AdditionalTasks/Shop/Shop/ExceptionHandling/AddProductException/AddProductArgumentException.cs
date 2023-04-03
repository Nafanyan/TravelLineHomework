namespace Shop.ExceptionHandling.AddProductException
{
    internal class AddProductArgumentException : ArgumentException
    {
        public AddProductArgumentException(string message) : base(message) { }
    }
}
