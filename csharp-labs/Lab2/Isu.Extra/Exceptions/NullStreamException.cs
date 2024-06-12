namespace Isu.Extra.Exceptions
{
    public class NullStreamException : Exception
    {
        public NullStreamException()
            : base("No students on this stream")
        {
        }

        public NullStreamException(string message)
            : base(message)
        {
        }
    }
}
