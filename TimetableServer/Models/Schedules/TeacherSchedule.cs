using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TimetableServer.Models.Schedules
{
    public class TeacherSchedule: BaseSchedule
    {
        private readonly DataBase _db;
        public TeacherSchedule(string id)
        {
            _db = _db ?? new DataBase();
            var teacher = _db.getTeacher(id);
            name = $"{teacher.title} {teacher.name} {teacher.surname}";
            scheduled = Converter.ConvertToDaysOfTheWeek(teacher.lessons.Where(t => t.start != null).GroupBy(t => t.day.name).ToList());
            notScheduled = Converter.ConvertToLesson(teacher.lessons.Where(t => t.start == null).ToList());
        }
    }
}