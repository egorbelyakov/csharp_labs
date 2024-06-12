using Isu.Exceptions;
using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Models;

namespace Isu.Extra.Services
{
    public class IsuExtraService : IIsuExtraService
    {
        private const int MaxCapacity = 30;
        private int currentStreamId = 10;
        private int currentId = 100000;

        private List<Ognp> ognpList = new List<Ognp>();
        private List<StudentExtra> studentsList = new List<StudentExtra>();
        private List<GroupExtra> groupsList = new List<GroupExtra>();

        public GroupExtra AddGroup(GroupName name, Timetable timetable)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(timetable);

            if (groupsList.Exists(x => x.Name == name))
                throw new GroupAlreadyExistsException("Group already exists");

            var group = new GroupExtra(name, timetable);
            groupsList.Add(group);

            return group;
        }

        public StudentExtra AddStudent(GroupExtra group, string name)
        {
            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(name);

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Invalid name error");

            if (group.GroupCapacity >= MaxCapacity)
                throw new GroupOverflowException("Overflow group");

            var student = new StudentExtra(group, name, currentId);
            currentId++;
            studentsList.Add(student);
            group.CapacityIncrementation();

            return student;
        }

        public Ognp CreateOgnp(string name, char faculty)
        {
            ArgumentNullException.ThrowIfNull(faculty);

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Invalid name error");

            var ognp = new Ognp(name, faculty);
            ognpList.Add(ognp);

            return ognp;
        }

        public void UnregisterStudentFromOgnp(StudentExtra student, OgnpStream ognpStream)
        {
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(ognpStream);

            student.RemoveStudentFromOgnp(ognpStream);
            ognpStream.RemoveStudentFromOgnpStream(student);
        }

        public IReadOnlyList<StudentExtra> GetStudentsFromOgnpGroup(OgnpStream stream)
        {
            ArgumentNullException.ThrowIfNull(stream);

            return stream.ShowStudentsOnStream() ?? throw new NullStreamException("No students on this stream");
        }

        public IReadOnlyList<StudentExtra> FindStudentsFromOgnpGroup(OgnpStream stream)
        {
            ArgumentNullException.ThrowIfNull(stream);

            try
            {
                return GetStudentsFromOgnpGroup(stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IReadOnlyList<StudentExtra> GetStudentsWithoutOgnp(GroupExtra group)
        {
            ArgumentNullException.ThrowIfNull(group);

            if (!groupsList.Contains(group))
                throw new NonExistableGroupException("This group does not exist");

            // var result = studentsList.Where(student => (student.StudentGroup == group) && (student.StudentsOgnpAmount() < 2)).ToList();
            var result = new List<StudentExtra>();

            foreach (StudentExtra student in studentsList)
            {
                if (student.StudentGroup == group && student.StudentsOgnpAmount() < 2)
                    result.Add(student);
            }

            return result ?? throw new NoStudentsWithoutOgnpException("No students without OGNP in this group");
        }

        public IReadOnlyList<StudentExtra> FindStudentsWithoutOgnp(GroupExtra group)
        {
            ArgumentNullException.ThrowIfNull(group);

            try
            {
                return GetStudentsWithoutOgnp(group);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void AddStudentToOgnp(StudentExtra student, OgnpStream ognpStream)
        {
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(ognpStream);

            student.AddStudentToOgnp(ognpStream);
            ognpStream.AddStudentToOgnpStream(student);
        }

        public OgnpStream CreateOgnpStream(Ognp ognp, Timetable timetable)
        {
            currentStreamId++;

            var stream = new OgnpStream(timetable, currentStreamId, ognp);
            ognp.AddStream(stream);

            return stream;
        }

        public IReadOnlyList<OgnpStream> ShowStreamsInOgnp(Ognp ognp) => ognp.ShowStreams();
    }
}
