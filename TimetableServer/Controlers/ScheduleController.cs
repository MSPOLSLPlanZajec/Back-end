using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableServer.Models;
using TimetableServer.Models.Schedules;

namespace TimetableServer.Controlers
{
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
