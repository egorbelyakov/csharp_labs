using Isu.Entities;
using Isu.Models;

namespace Isu.Extra.Entities
{
    public class GroupExtra : Group
    {
        public GroupExtra(GroupName name, Timetable timetable)
            : base(name)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(timetable);

            GroupCapacity = 0;
            GroupTimetable = timetable;
        }

        public new int GroupCapacity { get; private set; }
        public Timetable GroupTimetable { get; private set; }
    }
}
