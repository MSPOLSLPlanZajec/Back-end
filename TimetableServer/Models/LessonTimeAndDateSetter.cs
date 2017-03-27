using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class LessonTimeAndDateSetter
    {
        public string id { get; set; }
        public int day { get; set; }
        public int startsAt { get; set; }
    }
}