namespace Shops.Exceptions
{
    public class IncorrectNameException : Exception
    {
        public IncorrectNameException()
            : base("Invalid name")
        {
        }

        public IncorrectNameException(string message)
            : base(message)
        {
        }
    }
}
