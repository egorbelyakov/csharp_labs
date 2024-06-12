namespace Isu.Extra.Exceptions
{
    public class IncorrectWeekdayException : Exception
    {
        public IncorrectWeekdayException()
            : base("Weekday must be > 0 and < 6")
        {
        }

        public IncorrectWeekdayException(string message)
            : base(message)
        {
        }
    }
}
