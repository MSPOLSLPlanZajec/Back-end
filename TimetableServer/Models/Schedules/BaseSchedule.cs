using System.Collections.Generic;

namespace TimetableServer.Models.Schedules
{
    public abstract class BaseSchedule
    {
        public string name { get; set; }
        public List<List<Lesson>> scheduled { get; set; }
        public List<Lesson> notScheduled { get; set; }
    }
}