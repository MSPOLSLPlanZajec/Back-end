using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
                    var studyPlanObj = JsonConvert.DeserializeObject<StudyPlan>(value.data.ToString());                    
                    return JObject.Parse(JsonConvert.SerializeObject(studyPlanObj));
                case "add_classroom":
                    var classroomObj = JsonConvert.DeserializeObject<Classroom>(value.data.ToString());
                    classroomObj.id = "50";
                    return JObject.Parse(JsonConvert.SerializeObject(classroomObj));
                case "add_teacher":
                    var teacher = JsonConvert.DeserializeObject<Teacher>(value.data.ToString());
                    teacher.id = "XD";
                    return JObject.Parse(JsonConvert.SerializeObject(teacher));
                case "select_start":
                    var lessonTDS = JsonConvert.DeserializeObject<LessonTimeAndDateSetter>(value.data.ToString());
                    return JObject.Parse(JsonConvert.SerializeObject(lessonTDS));
                default:
                    return null;
            }
        }
    }
}
