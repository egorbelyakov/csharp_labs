namespace Isu.Exceptions
{
    public class GroupAlreadyExistsException : Exception
    {
        public GroupAlreadyExistsException()
            : base("Group already exists")
        {
        }

        public GroupAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
