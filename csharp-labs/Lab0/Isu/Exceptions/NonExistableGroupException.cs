namespace Isu.Exceptions
{
    public class NonExistableGroupException : Exception
    {
        public NonExistableGroupException()
            : base("Group does not exist")
        {
        }

        public NonExistableGroupException(string message)
            : base(message)
        {
        }
    }
}
