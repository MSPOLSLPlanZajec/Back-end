using System;
using System.Linq;

namespace TimetableServer.Models.Schedules
{
    public class GroupSchedule: BaseSchedule
    {
        private readonly DataBase _db;

        public GroupSchedule(string id)
        {
            _db = _db ?? new DataBase();
            PopulateSchedule(id);
        }

        public void PopulateSchedule(string id)
        {
            var group = _db.getGroup(id);
            Name = $"{group.name}";
            Scheduled = Converter.ConvertToDaysOfTheWeek(group.lessons.Where(t => t.start != null).GroupBy(t => t.day.name).ToList());
            NotScheduled = Converter.ConvertToLesson(group.lessons.Where(t => t.start == null).ToList());
        }
    }
}