using System.Collections.Generic;

namespace TimetableServer.Models.Schedules
{
    public abstract class BaseSchedule
    {
        public string Name { get; set; }
        public List<DayOfTheWeek> Scheduled { get; set; }
        public List<Lesson> NotScheduled { get; set; }
    }
}