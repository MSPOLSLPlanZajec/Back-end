using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class TimeSuggestion
    {
        public int startsAt { get; set; }
        public int duration { get; set; }
        public List<Classroom> possibleClassrooms { get; set; }
    }
}