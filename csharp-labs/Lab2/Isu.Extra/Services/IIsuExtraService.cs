using Isu.Extra.Entities;
using Isu.Models;

namespace Isu.Extra.Services
{
    public interface IIsuExtraService
    {
        GroupExtra AddGroup(GroupName name, Timetable timetable);
        StudentExtra AddStudent(GroupExtra group, string name);
        Ognp CreateOgnp(string name, char faculty);
        void AddStudentToOgnp(StudentExtra student, OgnpStream ognpStream);
        void UnregisterStudentFromOgnp(StudentExtra student, OgnpStream ognpStream);
        IReadOnlyList<StudentExtra> GetStudentsFromOgnpGroup(OgnpStream stream);
        IReadOnlyList<StudentExtra> GetStudentsWithoutOgnp(GroupExtra group);
        IReadOnlyList<StudentExtra> FindStudentsFromOgnpGroup(OgnpStream stream);
        IReadOnlyList<StudentExtra> FindStudentsWithoutOgnp(GroupExtra group);
        IReadOnlyList<OgnpStream> ShowStreamsInOgnp(Ognp ognp);
        OgnpStream CreateOgnpStream(Ognp ognp, Timetable timetable);
    }
}
