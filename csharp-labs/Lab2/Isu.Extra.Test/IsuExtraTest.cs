// using Isu.Extra.Exceptions;
using Isu.Extra.Entities;
using Isu.Extra.Services;
using Isu.Models;
using Xunit;

namespace Isu.Extra.Test;

public class IsuExtraTest
{
    private IsuExtraService service = new IsuExtraService();

    [Fact]
    public void AddAndDeleteStudentTest()
    {
        var timetable = new Timetable();
        var timetable2 = new Timetable();
        var name = new GroupName("M32111");

        Ognp ognp = service.CreateOgnp("Cybersafity", 'K');
        OgnpStream stream = service.CreateOgnpStream(ognp, timetable);
        GroupExtra group = service.AddGroup(name, timetable2);
        StudentExtra student = service.AddStudent(group, "name");
        StudentExtra student2 = service.AddStudent(group, "name2");

        service.AddStudentToOgnp(student, stream);
        service.AddStudentToOgnp(student2, stream);
        service.UnregisterStudentFromOgnp(student2, stream);

        Assert.True(student2.StudentsOgnpAmount() == 0);
        Assert.True(stream.ContainsStudent(student));
    }

    [Fact]
    public void GetOgnpStreamsTest()
    {
        var timetable = new Timetable();
        var timetable2 = new Timetable();

        Ognp ognp = service.CreateOgnp("Cybersafity", 'K');
        OgnpStream stream = service.CreateOgnpStream(ognp, timetable);
        OgnpStream stream2 = service.CreateOgnpStream(ognp, timetable2);

        var result = new List<OgnpStream> { stream, stream2 };

        Assert.Equal(result, service.ShowStreamsInOgnp(ognp));
    }

    [Fact]
    public void GetStudentsInStreamTest()
    {
        var timetable = new Timetable();
        var timetable2 = new Timetable();
        var name = new GroupName("M32111");

        Ognp ognp = service.CreateOgnp("Cybersafity", 'K');
        GroupExtra group = service.AddGroup(name, timetable2);
        OgnpStream stream = service.CreateOgnpStream(ognp, timetable);
        StudentExtra student = service.AddStudent(group, "name");
        StudentExtra student2 = service.AddStudent(group, "name2");

        service.AddStudentToOgnp(student, stream);
        service.AddStudentToOgnp(student2, stream);

        var result = new List<StudentExtra> { student, student2 };

        Assert.Equal(result, service.FindStudentsFromOgnpGroup(stream));
    }

    [Fact]
    public void GetWithoutOgnpTest()
    {
        var timetable = new Timetable();
        var name = new GroupName("M32111");

        GroupExtra group = service.AddGroup(name, timetable);
        StudentExtra student = service.AddStudent(group, "name");
        StudentExtra student2 = service.AddStudent(group, "name2");

        var result = new List<StudentExtra> { student, student2 };

        Assert.Equal(result, service.FindStudentsWithoutOgnp(group));
    }
}
