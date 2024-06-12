namespace Shops.Exceptions
{
    public class NonPositivePriceException : Exception
    {
        public NonPositivePriceException()
           : base("Price must be >= 0")
        {
        }

        public NonPositivePriceException(string message)
            : base(message)
        {
        }
    }
}
