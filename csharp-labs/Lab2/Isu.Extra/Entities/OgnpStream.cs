using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities
{
    public class OgnpStream
    {
        private const int MaxStudentsOnStream = 30;
        private List<StudentExtra> studentOnStream = new List<StudentExtra>();

        public OgnpStream(Timetable timetable, int id, Ognp ognpName)
        {
            ArgumentNullException.ThrowIfNull(timetable);
            ArgumentNullException.ThrowIfNull(id);

            if (id < 1)
                throw new IncorrectIdException("Id must be > 0");

            studentOnStream = new List<StudentExtra>();
            StreamTimetable = timetable;
            Id = id;
            OgnpName = ognpName;
        }

        public int Id { get; }
        public Timetable StreamTimetable { get; }
        public Ognp OgnpName { get; private set; }

        public void AddStudentToOgnpStream(StudentExtra student)
        {
            ArgumentNullException.ThrowIfNull(student);

            if (student.StudentGroup.Name.Name[0] == OgnpName.Faculty)
                throw new SameFacultyException("Student has the same faculty as this OGNP");

            if (student.StudentGroup.GroupTimetable.Lessons.Intersect(StreamTimetable.Lessons).Any())
                throw new OverlappingShedulesException("Shedules overlap");

            if (ContainsStudent(student))
                throw new StudentAlreadyOnThisStreamException("Student is already on this stream");

            studentOnStream.Add(student);
        }

        public void RemoveStudentFromOgnpStream(StudentExtra student)
        {
            ArgumentNullException.ThrowIfNull(student);

            studentOnStream.Remove(student);
        }

        public IReadOnlyList<StudentExtra> ShowStudentsOnStream()
        {
            return studentOnStream;
        }

        public bool ContainsStudent(StudentExtra student)
            => studentOnStream.Contains(student);
    }
}
