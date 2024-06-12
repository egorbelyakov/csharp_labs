namespace Isu.Exceptions
{
    public class GroupOverflowException : Exception
    {
        public GroupOverflowException()
            : base("Overflow group error")
        {
        }

        public GroupOverflowException(string message)
            : base(message)
        {
        }
    }
}
