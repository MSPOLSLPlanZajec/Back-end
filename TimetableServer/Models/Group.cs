using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class Group
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Group> Groups { get; set; } 
    }
}