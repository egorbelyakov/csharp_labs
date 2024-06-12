namespace Isu.Extra.Exceptions
{
    public class IncorrectLessonNumberException : Exception
    {
        public IncorrectLessonNumberException()
            : base("Lesson number must be > 0")
        {
        }

        public IncorrectLessonNumberException(string message)
            : base(message)
        {
        }
    }
}
