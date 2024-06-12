namespace Isu.Extra.Entities
{
    public class Timetable
    {
        private List<Lesson> timetable = new List<Lesson>();
        public Timetable()
        {
            timetable = new List<Lesson>();
        }

        public IReadOnlyList<Lesson> Lessons => timetable;

        public void AddLesson(Lesson lesson)
        {
            ArgumentNullException.ThrowIfNull(lesson);

            timetable.Add(lesson);
        }
    }
}
