using System.Collections.Generic;

namespace TimetableServer.Models.Schedules
{
    public abstract class BaseSchedule
    {
        public string name { get; set; }
        public List<DayOfTheWeek> scheduled { get; set; }
        public List<Lesson> notScheduled { get; set; }
    }
}