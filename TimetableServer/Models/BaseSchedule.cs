using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class BaseSchedule
    {
        public string name { get; set; }
        public List<DayOfTheWeek> scheduled { get; set; }
        public List<Lesson> notScheduled { get; set; }
    }
}