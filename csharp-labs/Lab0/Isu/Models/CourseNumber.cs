using Isu.Exceptions;

namespace Isu.Models;

public class CourseNumber
{
    private const int MinCourseNumber = 1;
    private const int MaxCourseNumber = 4;
    public CourseNumber(string numberOfCourse)
    {
        ArgumentNullException.ThrowIfNull(numberOfCourse);

        int courseNumber;
        if (!int.TryParse(numberOfCourse, out courseNumber) && courseNumber is < MinCourseNumber or > MaxCourseNumber)
        {
            throw new CourseNumberException(courseNumber);
        }

        NumberOfCource = courseNumber;
    }

    public int NumberOfCource { get; }
}