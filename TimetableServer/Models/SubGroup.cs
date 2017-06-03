using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class SubGroup
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Lesson> subjects { get; set; }
        public List<SubGroup> subgroups { get; set; }
    }
}