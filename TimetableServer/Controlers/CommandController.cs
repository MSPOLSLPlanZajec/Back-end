using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TimetableServer.Models;
using System.Web.Http.Cors;

namespace TimetableServer.Controlers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommandController : ApiController
    {
        private DataBase db = new DataBase();

        // POST: Command
        //[Authorize]
        public JObject Post([FromBody] Command value)
        {
            db = db ?? new DataBase();
            switch (value.Type)
            {
                case "add_study_plan":
                    return addStudyPlan(value);
                case "add_classroom":
                    return addClassroom(value);
                case "add_teacher":
                    return addTeacher(value);
                case "select_start":
                    return selectStart(value);
                default:
                    return null;
            }
        }

        private JObject selectStart(Command value)
        {
            var lessonTDS = JsonConvert.DeserializeObject<LessonTimeAndDateSetter>(value.Data.ToString());
            lesson lesson = db.getLesson(lessonTDS.Id);
            lesson.iddays = lessonTDS.Day.ToString();
            lesson.start = lessonTDS.StartsAt;
            lesson.idclassrooms= lessonTDS.ClassroomId;
            db.updateLesson(lessonTDS.Id, lesson);
            return JObject.Parse(JsonConvert.SerializeObject(lessonTDS));
        }

        private JObject addTeacher(Command value)
        {
            var teacherObj = JsonConvert.DeserializeObject<Teacher>(value.Data.ToString());
            teacher teacher = Converter.ConvertTeacherToDbTeacher(teacherObj);
            teacher.idteachers = Guid.NewGuid().ToString().Replace("-", "");
            db.insertTeacher(ref teacher);
            teacherObj.Id = teacher.idteachers;
            return JObject.Parse(JsonConvert.SerializeObject(teacherObj));
        }

        private JObject addClassroom(Command value)
        {
            var classroomObj = JsonConvert.DeserializeObject<Classroom>(value.Data.ToString());
            classroom classroom = Converter.ConvertClassRooomToDbClassRoom(classroomObj);
            
          
            classroom.idclassrooms = Guid.NewGuid().ToString().Replace("-", "");
            db.insertClassRoom(ref classroom);
            classroomObj.Id = classroom.idclassrooms;
            return JObject.Parse(JsonConvert.SerializeObject(classroomObj));
        }

        private JObject addStudyPlan(Command value)
        {
            var studyPlanObj = JsonConvert.DeserializeObject<StudyPlan>(value.Data.ToString());
            faculty major = new faculty();
            major.name = studyPlanObj.Major;
            major.idfaculty = Guid.NewGuid().ToString().Substring(0, 32).Replace("-", "");
            studyPlanObj.Id = major.idfaculty;
            db.insertFaculty(ref major);
            foreach (SubGroup it in studyPlanObj.Semesters)
            {
                semester semester = new semester();
                semester.idsemesters = Guid.NewGuid().ToString().Replace("-", "");
                semester.name = it.Name;
                db.insertSemester(ref semester);
                addGroup(it, semester.idsemesters, null, major.idfaculty);

            }

            return JObject.Parse(JsonConvert.SerializeObject(studyPlanObj));
        }

        private void addGroup(SubGroup subgroup, string semesterID, string superGroupID, string majorID)
        {
            group group = new group();
            group.idgroups = Guid.NewGuid().ToString().Replace("-", "");
            subgroup.Id = group.idgroups;
            group.name = subgroup.Name;
            group.idsemesters = semesterID;
            group.idsupergroup = superGroupID;
            group.idfaculty = majorID;
            db.insertGroup(ref group);
            foreach (SubGroup it in subgroup.Subgroups)
            {
                addGroup(it, semesterID, group.idgroups, majorID);
            }
            foreach (Lesson it in subgroup.Subjects)
            {
                addSubject(it, group.idgroups);
            }

        }

        private void addSubject(Lesson it, string groupID)
        {
            lesson lesson = new lesson();
            lesson.idlessons = Guid.NewGuid().ToString().Replace("-", "");
            lesson.idteachers = it.TeacherId;
            lesson.idsubjects = findSubjectID(it.Name, it.Type, it.Duration);
            lesson.idgroups = groupID;
            lesson.idclassrooms = "a";
            db.insertLesson(ref lesson);

        }

        private string findSubjectID(string name, string type, int duration)
        {
            foreach (var it in db.getAllSubjects())
            {
                if (it.name == name && it.time == duration.ToString() && it.type == type)
                    return it.idsubjects;
            }
            subject subject = new subject();
            subject.idsubjects = Guid.NewGuid().ToString().Replace("-", "");
            subject.name = name;
            subject.time = duration.ToString();
            subject.type = type;
            db.insertSubject(ref subject);
            return subject.idsubjects;
        }
    }
}
