namespace Isu.Extra.Exceptions
{
    public class SameFacultyException : Exception
    {
        public SameFacultyException()
            : base("Student has the same faculty as this OGNP")
        {
        }

        public SameFacultyException(string message)
            : base(message)
        {
        }
    }
}
