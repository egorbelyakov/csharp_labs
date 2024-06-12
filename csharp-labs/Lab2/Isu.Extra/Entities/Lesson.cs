using Isu.Exceptions;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities
{
    public class Lesson : IEquatable<Lesson>
    {
        public Lesson(int auditory, string teacher, string name, int number, int weekday)
        {
            if (string.IsNullOrWhiteSpace(teacher) || string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Invalid name");

            if (auditory < 1)
                throw new IncorrectAuditoryException("Auditory number must be > 0");

            if (number < 1)
                throw new IncorrectLessonNumberException("Lesson number must be > 0");

            if (weekday < 1)
                throw new IncorrectWeekdayException("Weekday must be > 0");

            ArgumentNullException.ThrowIfNull(auditory);
            ArgumentNullException.ThrowIfNull(number);
            ArgumentNullException.ThrowIfNull(weekday);

            Auditory = auditory;
            Teacher = teacher;
            Name = name;
            Number = number;
            Weekday = weekday;
        }

        public int Weekday { get; }
        public int Auditory { get; }
        public string Teacher { get; }
        public string Name { get; }
        public int Number { get; }

        public bool Equals(Lesson other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Weekday == other.Weekday && Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Lesson)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Weekday, Number);
        }
    }
}
