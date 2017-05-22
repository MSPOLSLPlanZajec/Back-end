using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace TimetableServer.Models
{
    public class Command
    {
        public string Type { get; set; }
        public JObject Data { get; set; }
    }
}