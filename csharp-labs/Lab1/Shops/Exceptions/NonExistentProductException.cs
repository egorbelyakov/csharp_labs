namespace Shops.Exceptions
{
    public class NonExistentProductException : Exception
    {
        public NonExistentProductException()
            : base("Product does not exist")
        {
        }

        public NonExistentProductException(string message)
            : base(message)
        {
        }
    }
}
