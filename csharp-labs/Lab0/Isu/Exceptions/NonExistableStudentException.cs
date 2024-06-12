namespace Isu.Exceptions
{
    public class NonExistableStudentException : Exception
    {
        public NonExistableStudentException()
            : base("Student is not found")
        {
        }

        public NonExistableStudentException(string message)
            : base(message)
        {
        }
    }
}
