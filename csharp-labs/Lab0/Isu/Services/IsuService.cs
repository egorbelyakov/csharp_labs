using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private int currentId = 100000;
        private int maxCapacity = 30;
        private List<Group> groups = new List<Group>();
        private List<Student> students = new List<Student>();

        public IsuService()
        {
            groups = new List<Group>();
            students = new List<Student>();
        }

        public Group AddGroup(GroupName name)
        {
            ArgumentNullException.ThrowIfNull(name);

            if (groups.Exists(x => x.Name == name))
                throw new GroupAlreadyExistsException("Group already exists");

            var group = new Group(name);
            groups.Add(group);

            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(name);

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException("Invalid name error");
            }

            if (group.GroupCapacity >= maxCapacity)
                throw new GroupOverflowException("Overflow group");

            var student = new Student(group, name, currentId);
            currentId++;
            students.Add(student);
            group.CapacityIncrementation();

            return student;
        }

        public Group GetGroup(GroupName groupName)
        {
            ArgumentNullException.ThrowIfNull(groupName);

            return groups
                .SingleOrDefault(groups => groups.Name == groupName)
                ?? throw new NonExistableGroupException("Group does not exist");
        }

        public Group FindGroup(GroupName groupName)
        {
            ArgumentNullException.ThrowIfNull(groupName);

            try
            {
                return GetGroup(groupName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Student GetStudent(int id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return students
                .SingleOrDefault(students => students.Id == id)
                ?? throw new NonExistableStudentException($"Student is not found");
        }

        public Student FindStudent(int id)
        {
            ArgumentNullException.ThrowIfNull(id);

            try
            {
                return GetStudent(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IReadOnlyCollection<Student> FindStudents(GroupName groupName)
        {
            ArgumentNullException.ThrowIfNull(groupName);

            var result = students.Where(student => student.Group.Name == groupName).ToList();

            return result;
        }

        public IReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber)
        {
            ArgumentNullException.ThrowIfNull(courseNumber);

            var result = groups.Where(group => group.NumberOfCourse == courseNumber).ToList();

            return result;
        }

        public IReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber)
        {
            ArgumentNullException.ThrowIfNull(courseNumber);

            var result = students.Where(student => courseNumber == student.Group.NumberOfCourse).ToList();

            return result;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(newGroup);

            if (newGroup.GroupCapacity >= maxCapacity)
            {
                throw new GroupOverflowException("Group is full");
            }

            Group oldGroup = student.Group;
            oldGroup.CapacityDecrementation();
            student.GroupChange(newGroup);
            newGroup.CapacityIncrementation();
        }
    }
}
