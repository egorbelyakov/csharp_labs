namespace Shops.Exceptions
{
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException()
            : base("Balance must be > 0")
        {
        }

        public NegativeBalanceException(string message)
            : base(message)
        {
        }
    }
}
