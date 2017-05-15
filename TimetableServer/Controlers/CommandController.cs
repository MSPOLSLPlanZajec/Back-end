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
        public JObject Post([FromBody] Command value)
        {
            db = db ?? new DataBase();
            switch (value.type)
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
            var lessonTDS = JsonConvert.DeserializeObject<LessonTimeAndDateSetter>(value.data.ToString());
            lesson lesson = db.getLesson(lessonTDS.id);
            lesson.iddays = lessonTDS.day.ToString();

            //brakuje w bazie (lub ja nie umiem znaleźć)
            //lesson.startsAt = lessonTDS.startsAt;
            db.updateLesson(lessonTDS.id, lesson);
            return JObject.Parse(JsonConvert.SerializeObject(lessonTDS));
        }

        private JObject addTeacher(Command value)
        {
            var teacherObj = JsonConvert.DeserializeObject<Teacher>(value.data.ToString());
            teacher teacher = new teacher();
            teacher.name = teacherObj.name;
            teacher.surname = teacherObj.surname;
            teacher.idtitles = teacherObj.title;
            teacher.idteachers = Guid.NewGuid().ToString().Substring(0, 32);
            db.insertTeacher(ref teacher);
            teacherObj.id = teacher.idteachers;
            return JObject.Parse(JsonConvert.SerializeObject(teacherObj));
        }

        private JObject addClassroom(Command value)
        {
            var classroomObj = JsonConvert.DeserializeObject<Classroom>(value.data.ToString());
            classroom classroom = new classroom();
            classroom.number = classroomObj.name;
            //TODO ewentualnie zwiększyć maksymalną długość w bazie
            classroom.idclassrooms = Guid.NewGuid().ToString().Substring(0, 32);
            db.insertClassRoom(ref classroom);
            classroomObj.id = classroom.idclassrooms;
            return JObject.Parse(JsonConvert.SerializeObject(classroomObj));
        }

        private JObject addStudyPlan(Command value)
        {
            var studyPlanObj = JsonConvert.DeserializeObject<StudyPlan>(value.data.ToString());
            faculty major = new faculty();
            major.name = studyPlanObj.major;
            major.idfaculty = Guid.NewGuid().ToString().Substring(0, 32);
            studyPlanObj.id = major.idfaculty;
            db.insertFaculty(ref major);
            foreach (SubGroup it in studyPlanObj.semesters)
            {
                semester semester = new semester();
                semester.idsemesters = Guid.NewGuid().ToString().Substring(0, 32);
                semester.name = it.name;
                db.insertSemester(ref semester);
                addGroup(it, semester.idsemesters, null, major.idfaculty);

            }

            return JObject.Parse(JsonConvert.SerializeObject(studyPlanObj));
        }

        private void addGroup(SubGroup subgroup, string semesterID, string superGroupID, string majorID)
        {
            group group = new group();
            group.idgroups = Guid.NewGuid().ToString().Substring(0, 32);
            subgroup.id = group.idgroups;
            group.name = subgroup.name;
            group.idsemesters = semesterID;
            group.idsupergroup = superGroupID;
            group.idfaculty = majorID;
            db.insertGroup(ref group);
            foreach (SubGroup it in subgroup.subgroups)
            {
                addGroup(it, semesterID, group.idgroups, majorID);
            }
            foreach (Lesson it in subgroup.subjects)
            {
                addSubject(it, group.idgroups);
            }

        }

        private void addSubject(Lesson it, string groupID)
        {
            lesson lesson = new lesson();
            lesson.idlessons = Guid.NewGuid().ToString().Substring(0, 32);
            lesson.idteachers = it.teacher_id;
            lesson.idsubjects = findSubjectID(it.name, it.type, it.duration);
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
            subject.idsubjects = Guid.NewGuid().ToString().Substring(0, 32);
            subject.name = name;
            subject.time = duration.ToString();
            subject.type = type;
            db.insertSubject(ref subject);
            return subject.idsubjects;
        }
    }
}
