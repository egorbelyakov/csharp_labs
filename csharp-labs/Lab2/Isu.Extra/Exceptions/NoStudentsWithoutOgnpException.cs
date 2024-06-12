namespace Isu.Extra.Exceptions
{
    public class NoStudentsWithoutOgnpException : Exception
    {
        public NoStudentsWithoutOgnpException()
            : base("Weekday must be > 0 and < 6")
        {
        }

        public NoStudentsWithoutOgnpException(string message)
            : base(message)
        {
        }
    }
}
