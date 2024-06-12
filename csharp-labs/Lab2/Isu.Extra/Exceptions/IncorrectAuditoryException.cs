namespace Isu.Extra.Exceptions
{
    public class IncorrectAuditoryException : Exception
    {
        public IncorrectAuditoryException()
            : base("Auditory number must be > 0")
        {
        }

        public IncorrectAuditoryException(string message)
            : base(message)
        {
        }
    }
}
