using System;
using System.Collections.Generic;
using System.Linq;

namespace TimetableServer.Models.Schedules
{
    public class TeacherSchedule: BaseSchedule
    {
        private readonly DataBase _db;
        public TeacherSchedule(string id)
        {
            _db = _db ?? new DataBase();
            PopulateSchedule(id);
        }

        private void PopulateSchedule(string id)
        {
            var teacher = _db.getTeacher(id);
            Name = $"{teacher.title} {teacher.name} {teacher.surname}";
            Scheduled = Converter.ConvertToDaysOfTheWeek(teacher.lessons.Where(t => t.start != null).GroupBy(t=>t.day.name).ToList());
            NotScheduled = Converter.ConvertToLesson(teacher.lessons.Where(t => t.start == null).ToList());
        }
    }
}