namespace Backups.Exceptions
{
    public class BackupsException : Exception
    {
        public BackupsException()
            : base(" ")
        {
        }

        public BackupsException(string message)
            : base(message)
        {
        }
    }
}
