using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class Lesson
    {
        public string name { get; set; }
        public Teacher teacher { get; set; }
        public string teacherId { get; set; }
        public Classroom classroom { get; set; }
        public Group group { get; set; }
        public string type { get; set; }
        public int duration { get; set; }
        public int startsAt { get; set; }
    }
}