namespace Shops.Exceptions
{
    public class IncorrectAmountException : Exception
    {
        public IncorrectAmountException()
            : base("Amount must be > 0")
        {
        }

        public IncorrectAmountException(string message)
            : base(message)
        {
        }
    }
}
