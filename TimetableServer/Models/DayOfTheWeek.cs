using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class DayOfTheWeek
    {
        public string name { get; set; }
        public List<Lesson> scheduled { get; set; }

        public DayOfTheWeek(string name)
        {
            this.name = name;
            scheduled = new List<Lesson>();
        }

        public DayOfTheWeek()
        {
            
        }
    }
}