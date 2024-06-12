using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities
{
    public class Student
    {
        public Student(Group group, string name, int id)
        {
            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(id);

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException("Invalid name error");
            }

            Name = name;
            Group = group;
            Id = id;
        }

        public int Id { get; }
        public string Name { get; }
        public Group Group { get; private set; }

        public void GroupChange(Group group)
        {
            ArgumentNullException.ThrowIfNull(group);
            Group = group;
        }
    }
}
