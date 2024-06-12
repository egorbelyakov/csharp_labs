using Isu.Models;

namespace Isu.Entities;

public class Group
{
    public Group(GroupName name)
    {
        ArgumentNullException.ThrowIfNull(name);

        NumberOfCourse = name.NumberOfCourse;
        Name = name;
        GroupCapacity = 0;
    }

    public int GroupCapacity { get; private set; }
    public CourseNumber NumberOfCourse { get; }
    public GroupName Name { get; }

    public void CapacityIncrementation()
    {
        GroupCapacity++;
    }

    public void CapacityDecrementation()
    {
        GroupCapacity--;
    }
}