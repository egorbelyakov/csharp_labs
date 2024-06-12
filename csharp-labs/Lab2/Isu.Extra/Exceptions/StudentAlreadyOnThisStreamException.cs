namespace Isu.Extra.Exceptions
{
    public class StudentAlreadyOnThisStreamException : Exception
    {
        public StudentAlreadyOnThisStreamException()
            : base("Student is already on this stream")
        {
        }

        public StudentAlreadyOnThisStreamException(string message)
            : base(message)
        {
        }
    }
}
