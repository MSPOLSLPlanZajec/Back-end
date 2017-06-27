    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimetableServer.Models;

namespace TimetableServer
{
    public class Converter
    {
        public static List<Group> ConvertDbGroupsToGroups(List<group> dbGroups)
        {
            return dbGroups.Select(dbGroup => new Group
            {
                name = dbGroup.name, id = dbGroup.idgroups, groups = new List<Group>()
            }).ToList();
        }

        public static List<Lesson> ConvertToLesson(List<lesson> lessons)
        {
            DataBase db = new DataBase();
            return lessons.Select(
                t => new Lesson
                {
                    name = t.subject.name,
                    id  = t.idlessons,
                    teacher = new Teacher
                    {
                        id = t.teacher.idteachers,
                        name = t.teacher.name,
                        surname = t.teacher.surname,
                        title = t.teacher.title.name
                    },
                    teacher_id = t.teacher.idteachers,
                    classroom = t.classroom == null ? null : new Classroom
                    {
                        id = t.classroom.idclassrooms,
                        name = t.classroom.number 
                    },
                    group = new Group
                    {
                        groups = new List<Group>(),
                        id = t.group.idgroups,
                        name = t.group.name
                    },
                    type = db.getCRType(t.subject.type).name,
                    duration = t.subject.time.GetValueOrDefault(),
                    startsAt = t.start.GetValueOrDefault()
                }).ToList();
        }

        public static List<DayOfTheWeek> ConvertToDaysOfTheWeek(List<IGrouping<string, lesson>> groupedList, IEnumerable<string> days)
        {
            
            return (from it in days
                let dayOfTheWeek = groupedList.Select(day => new DayOfTheWeek
                {
                    name = day.Key, scheduled = ConvertToLesson(day.AsQueryable().ToList())
                }).Where(x => x.name == it)
                select (DayOfTheWeek) (dayOfTheWeek.Any() ? dayOfTheWeek.First() : new DayOfTheWeek(it))).ToList();

        }

        public static teacher ConvertTeacherToDbTeacher(Teacher teacherObj)
        {
            teacher teacher = new teacher();
            teacher.name = teacherObj.name;
            teacher.surname = teacherObj.surname;
            teacher.idtitles = teacherObj.title;
            teacher.idteachers = teacherObj.id;
            return teacher;
        }

        public static classroom ConvertClassRooomToDbClassRoom(Classroom classroomObj)
        {

            classroom classroom = new classroom();
            classroom.number = classroomObj.name;
            return classroom;
        }

        public static Degree ConvertToDegree(title titleToConvert)
        {
            return new Degree() {id = titleToConvert.idtitles, title = titleToConvert.name};
        }

        public static Teacher ConvertDbTeacherToTeacher(teacher t)
        {
            return new Teacher
            {
                name = t.name,
                id = t.idteachers,
                surname = t.surname,
                title = t.title.name
            };
        }

        public static Classroom ConvertDbClassroomToClassroom(classroom cr)
        {
            return new Classroom
            {
                id = cr.idclassrooms,
                name = cr.number,
                typeId = cr.idcroomtype
            };
        }

        public static LessonType ConvertClassroomTypeToLessonType(croomtype type)
        {
            return new LessonType
            {
                id = type.idcroomtype,
                name = type.name
            };
        }
    }
}