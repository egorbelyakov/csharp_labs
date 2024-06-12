namespace Isu.Extra.Exceptions;

public class OverlappingShedulesException : Exception
{
    public OverlappingShedulesException()
        : base("Shedules overlap")
    {
    }

    public OverlappingShedulesException(string message)
        : base(message)
    {
    }
}