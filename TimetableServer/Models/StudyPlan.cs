using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class StudyPlan
    {
        public string Id { get; set; }
        public string Major { get; set; }
        public List<SubGroup> Semesters { get; set; }
        
    }
}