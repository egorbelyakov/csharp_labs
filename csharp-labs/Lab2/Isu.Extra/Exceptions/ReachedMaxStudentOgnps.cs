namespace Isu.Extra.Exceptions
{
    public class ReachedMaxStudentOgnps : Exception
    {
        public ReachedMaxStudentOgnps()
            : base("Student can have only 2 OGNPs")
        {
        }

        public ReachedMaxStudentOgnps(string message)
            : base(message)
        {
        }
    }
}
