namespace Isu.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException()
            : base("Invalid name")
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }
    }
}
