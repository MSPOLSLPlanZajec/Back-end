using System;
using System.Collections.Generic;

namespace TimetableServer.Models.Schedules
{
    public class TeacherSchedule: BaseSchedule
    {
        public TeacherSchedule(string id)
        {
            name = "Jan Kowalski";
            scheduled = new List<DayOfTheWeek>();
            notScheduled = new List<Lesson>();
        }

        public override void populateSchedule(string id)
        {
            throw new NotImplementedException();
        }
    }
}