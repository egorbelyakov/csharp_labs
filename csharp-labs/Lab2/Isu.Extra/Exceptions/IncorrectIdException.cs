namespace Isu.Extra.Exceptions
{
    public class IncorrectIdException : Exception
    {
        public IncorrectIdException()
            : base("ID must be > 0")
        {
        }

        public IncorrectIdException(string message)
            : base(message)
        {
        }
    }
}
