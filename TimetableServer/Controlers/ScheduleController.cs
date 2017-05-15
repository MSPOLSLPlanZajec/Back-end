using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TimetableServer.Models;
using TimetableServer.Models.Schedules;

namespace TimetableServer.Controlers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ScheduleController : ApiController
    {
        public BaseSchedule GetSchedule(string id, string typeOfSchedule)
        {
            switch (typeOfSchedule)
            {
                case "teacher":
                    return new TeacherSchedule(id);
                case "group":
                    return new GroupSchedule(id);
                default:
                    return null;
            }
        }
    }
}
