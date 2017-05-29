using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class LessonTimeAndDateSetter
    {
        public string Id { get; set; }
        public int Day { get; set; }
        public int StartsAt { get; set; }
        public string ClassroomId { get; set; }
    }
}