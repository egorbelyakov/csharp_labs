namespace Isu.Exceptions
{
    public class WrongGroupNameException : Exception
    {
        public WrongGroupNameException()
            : base("Wrong group name error")
        {
        }

        public WrongGroupNameException(string message)
            : base(message)
        {
        }
    }
}
