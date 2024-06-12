using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Test;

public class Test
{
    private IsuService isu = new IsuService();

    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var name = new GroupName("M32111");
        Group group = isu.AddGroup(name);
        Student student = isu.AddStudent(group, "Name");

        Assert.Equal(student.Group.Name, group.Name);
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        int maxStudentsInGroup = 30;
        var name = new GroupName("M32111");
        var group = new Group(name);

        for (int i = 0; i <= maxStudentsInGroup; i++)
            group.CapacityIncrementation();

        Assert.Throws<GroupOverflowException>(() => isu.AddStudent(group, "Egor"));
    }

    [Theory]
    [InlineData("ABOBA")]
    [InlineData("AD<C\\2131")]
    public void CreateGroupWithInvalidName_ThrowException(string invalidName)
    {
        Assert.Throws<WrongGroupNameException>(() => isu.AddGroup(new GroupName(invalidName)));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var name1 = new GroupName("M32111");
        var name2 = new GroupName("M32110");
        Group group1 = isu.AddGroup(name1);
        Group group2 = isu.AddGroup(name2);

        Student student = isu.AddStudent(group1, "Name");

        isu.ChangeStudentGroup(student, group2);

        Assert.Equal(student.Group, group2);
        Assert.NotEqual(student.Group, group1);
    }
}