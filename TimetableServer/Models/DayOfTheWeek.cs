using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class DayOfTheWeek
    {
        public string Name { get; set; }
        public List<Lesson> Scheduled { get; set; } 
    }
}