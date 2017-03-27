using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    public class CommandController : ApiController
    {
        // POST: Command
        public JObject Post([FromBody] Command value)
        {
            switch (value.type)
            {
                case "add_study_plan":
                    return null;
                case "add_classroom":
                {
                    var obj = JsonConvert.DeserializeObject<Classroom>(value.data.ToString());
                    obj.id = "50";
                    return JObject.Parse(JsonConvert.SerializeObject(obj));
                }
                case "add_teacher":
                    return null;
                case "select_start":
                    return null;
                default:
                    return null;
            }
        }
    }
}
