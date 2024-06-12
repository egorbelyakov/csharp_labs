namespace Isu.Exceptions
{
    public class CourseNumberException : Exception
    {
        public CourseNumberException(int number)
            : base($"Course number {number} is invalid")
        {
        }
    }
}
