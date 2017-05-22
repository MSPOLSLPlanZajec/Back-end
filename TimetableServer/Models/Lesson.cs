using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class Lesson
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }
        public Classroom Classroom { get; set; }
        public Group Group { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public int StartsAt { get; set; }
    }
}