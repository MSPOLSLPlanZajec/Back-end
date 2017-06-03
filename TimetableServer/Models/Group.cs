using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer.Models
{
    public class Group
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<Group> groups { get; set; } 
    }
}