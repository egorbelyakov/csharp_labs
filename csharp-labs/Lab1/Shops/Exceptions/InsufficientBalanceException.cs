namespace Shops.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
            : base("You do not have enough money")
        {
        }

        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }
}
