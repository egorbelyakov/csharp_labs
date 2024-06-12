namespace Isu.Extra.Exceptions
{
    public class StudentDoNotHaveOgnpException : Exception
    {
        public StudentDoNotHaveOgnpException()
            : base("Student does not have ognp")
        {
        }

        public StudentDoNotHaveOgnpException(string message)
            : base(message)
        {
        }
    }
}
