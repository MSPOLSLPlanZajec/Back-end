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
            return lessons.Select(
                t => new Lesson
                {
                    name = t.subject.name,
                    teacher = new Teacher
                    {
                        id = t.teacher.idteachers,
                        name = t.teacher.name,
                        surname = t.teacher.surname,
                        title = t.teacher.title.name
                    },
                    teacherId = t.teacher.idteachers,
                    classroom = new Classroom
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
                    type = t.subject.type,
                    duration = int.Parse(t.subject.time),
                    startsAt = t.start.GetValueOrDefault()
                }).ToList();
        }

        public static List<DayOfTheWeek> ConvertToDaysOfTheWeek(List<IGrouping<string, lesson>> groupedList)
        {
            return groupedList.Select(day => new DayOfTheWeek
            {
                name = day.Key, scheduled = ConvertToLesson(day.AsQueryable().ToList())
            }).ToList();
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
                name = cr.number
            };
        }
    }
}