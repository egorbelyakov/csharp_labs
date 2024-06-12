namespace Shops.Exceptions
{
    public class NonExistentShopException : Exception
    {
        public NonExistentShopException()
            : base("Shop does not exist")
        {
        }

        public NonExistentShopException(string message)
            : base(message)
        {
        }
    }
}
