using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class SubGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Lesson> Subjects { get; set; }
        public List<SubGroup> Subgroups { get; set; }
    }
}