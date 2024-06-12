using System.Text.RegularExpressions;
using Isu.Exceptions;

namespace Isu.Models;

public class GroupName
{
    private static readonly Regex CheckPattern = new (@"^[A-Z][3][1-4]\d{2,3}", RegexOptions.Compiled);
    public GroupName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        GroupNameCheck(name);
        NumberOfCourse = new CourseNumber(name.Substring(3, 1));
        Name = name;
    }

    public CourseNumber NumberOfCourse { get; }
    public string Name { get; }

    public void GroupNameCheck(string groupName)
    {
        ArgumentNullException.ThrowIfNull(groupName);

        if (string.IsNullOrWhiteSpace(groupName))
        {
            throw new InvalidNameException("Invalid name error");
        }

        if (!CheckPattern.IsMatch(groupName))
        {
            throw new WrongGroupNameException("WrongGroupName");
        }
    }
}