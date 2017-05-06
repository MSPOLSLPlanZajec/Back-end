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
        private DataBase db = new DataBase();

        // POST: Command
        public JObject Post([FromBody] Command value)
        {
            db = db ?? new DataBase();
            switch (value.type)
            {
                case "add_study_plan":
                    var studyPlanObj = JsonConvert.DeserializeObject<StudyPlan>(value.data.ToString());
                    return JObject.Parse(JsonConvert.SerializeObject(studyPlanObj));

                case "add_classroom":
                    var classroomObj = JsonConvert.DeserializeObject<Classroom>(value.data.ToString());
                    classroom classroom = new classroom();
                    classroom.number = classroomObj.name;
                    //TODO ewentualnie zwiększyć maksymalną długość w bazie
                    classroom.idclassrooms = Guid.NewGuid().ToString().Substring(0, 32);
                    db.insertClassRoom(ref classroom);
                    classroomObj.id = classroom.idclassrooms;
                    return JObject.Parse(JsonConvert.SerializeObject(classroomObj));
                case "add_teacher":
                    var teacherObj = JsonConvert.DeserializeObject<Teacher>(value.data.ToString());
                    teacher teacher = new teacher();
                    teacher.name = teacherObj.name;
                    teacher.surname = teacherObj.surname;
                    teacher.idtitles = teacherObj.title;
                    teacher.idteachers = Guid.NewGuid().ToString().Substring(0, 32);
                    db.insertTeacher(ref teacher);
                    teacherObj.id = teacher.idteachers;
                    return JObject.Parse(JsonConvert.SerializeObject(teacherObj));
                case "select_start":

                    var lessonTDS = JsonConvert.DeserializeObject<LessonTimeAndDateSetter>(value.data.ToString());
                    lesson lesson = db.getLesson(lessonTDS.id);
                    lesson.iddays = lessonTDS.day.ToString();

                    //brakuje w bazie (lub ja nie umiem znaleźć)
                    //lesson.startsAt = lessonTDS.startsAt;
                    db.updateLesson(lessonTDS.id, lesson);
                    return JObject.Parse(JsonConvert.SerializeObject(lessonTDS));
                default:
                    return null;
            }
        }
    }
}
