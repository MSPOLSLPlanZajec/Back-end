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
            var group = _db.getGroup(id);
            name = $"{group.name}";
            scheduled = Converter.ConvertToDaysOfTheWeek(@group.lessons.Where(t => t.start != null).GroupBy(t => t.day.name).ToList(), _db.getAllDays().Select(x => x.name)).Select(x => x.scheduled).ToList();
            
            notScheduled = Converter.ConvertToLesson(group.lessons.Where(t => t.start == null).ToList());

            appendLessonsFromHigherGroups(group.group1);
        }

        private void appendLessonsFromHigherGroups(group gr)
        {
            if (gr != null)
            {
                var schGroupings =
                    Converter.ConvertToDaysOfTheWeek(
                        gr.lessons.Where(t => t.start != null).GroupBy(t => t.day.name).ToList(), _db.getAllDays().Select(x => x.name));
                for(var i = 0; i < scheduled.Count; i++)
                    scheduled[i].AddRange(schGroupings[i].scheduled);
                notScheduled.AddRange(Converter.ConvertToLesson(gr.lessons.Where(t => t.start == null).ToList()));
                appendLessonsFromHigherGroups(gr.group1);
            }
        }
    }
}