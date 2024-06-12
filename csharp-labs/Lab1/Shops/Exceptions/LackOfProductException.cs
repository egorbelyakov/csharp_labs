namespace Shops.Exceptions
{
    public class LackOfProductException : Exception
    {
        public LackOfProductException()
            : base("Not enough product in warehouse")
        {
        }

        public LackOfProductException(string message)
            : base(message)
        {
        }
    }
}
