namespace Isu.Exceptions
{
    public class NonExistableOrNullCourseException : Exception
    {
        public NonExistableOrNullCourseException()
            : base("Course does not exist or null")
        {
        }

        public NonExistableOrNullCourseException(string message)
            : base(message)
        {
        }
    }
}
