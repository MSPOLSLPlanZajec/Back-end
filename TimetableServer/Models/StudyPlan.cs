using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class StudyPlan
    {
        public string id { get; set; }
        public string major { get; set; }
        public List<SubGroup> semesters { get; set; }
        
    }
}