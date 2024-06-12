using Isu.Entities;
using Isu.Exceptions;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities
{
    public class StudentExtra : Student
    {
        private const int MaxStudentsOgnp = 2;
        private List<OgnpStream> ognpsList = new List<OgnpStream>();

        public StudentExtra(GroupExtra group, string name, int id)
            : base(group, name, id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Invalid name");

            if (id < 1)
                throw new IncorrectIdException("Id must be > 0");

            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(id);

            Name = name;
            Id = id;
            StudentGroup = group;
        }

        public new int Id { get; }
        public new string Name { get; }
        public GroupExtra StudentGroup { get; private set; }

        public void AddStudentToOgnp(OgnpStream ognpStream)
        {
            ArgumentNullException.ThrowIfNull(ognpStream);

            if (ognpsList.Count() > 2)
                throw new ReachedMaxStudentOgnps("Student can have only 2 OGNPs");

            ognpsList.Add(ognpStream);
        }

        public void RemoveStudentFromOgnp(OgnpStream ognpStream)
        {
            ArgumentNullException.ThrowIfNull(ognpStream);

            if (ognpsList.Count() == 0)
                throw new StudentDoNotHaveOgnpException("Student does not have ognp");

            ognpsList.Remove(ognpStream);
        }

        public int StudentsOgnpAmount()
        {
            return ognpsList.Count();
        }
    }
}
