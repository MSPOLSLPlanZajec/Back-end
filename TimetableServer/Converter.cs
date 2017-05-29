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
                Name = dbGroup.name, Id = dbGroup.idgroups, Groups = new List<Group>()
            }).ToList();
        }

        public static List<Lesson> ConvertToLesson(List<lesson> lessons)
        {
            return lessons.Select(
                t => new Lesson
                {
                    Name = t.subject.name,
                    Teacher = new Teacher
                    {
                        Id = t.teacher.idteachers,
                        Name = t.teacher.name,
                        Surname = t.teacher.surname,
                        Title = t.teacher.title.name
                    },
                    TeacherId = t.teacher.idteachers,
                    Classroom = new Classroom
                    {
                        Id = t.classroom.idclassrooms,
                        Name = t.classroom.number
                    },
                    Group = new Group
                    {
                        Groups = new List<Group>(),
                        Id = t.group.idgroups,
                        Name = t.group.name
                    },
                    Type = t.subject.type,
                    Duration = t.subject.time,
                    StartsAt = t.start
                }).ToList();
        }

        public static List<DayOfTheWeek> ConvertToDaysOfTheWeek(List<IGrouping<string, lesson>> groupedList)
        {
            return groupedList.Select(day => new DayOfTheWeek
            {
                Name = day.Key, Scheduled = ConvertToLesson(day.AsQueryable().ToList())
            }).ToList();
        }

        public static teacher ConvertTeacherToDbTeacher(Teacher teacherObj)
        {
            teacher teacher = new teacher();
            teacher.name = teacherObj.Name;
            teacher.surname = teacherObj.Surname;
            teacher.idtitles = teacherObj.Title;
            teacher.idteachers = teacherObj.Id;
            return teacher;
        }

        public static classroom ConvertClassRooomToDbClassRoom(Classroom classroomObj)
        {

            classroom classroom = new classroom();
            classroom.number = classroomObj.Name;
            return classroom;
        }

        public static Degree ConvertToDegree(title titleToConvert)
        {
            return new Degree() {Id = titleToConvert.idtitles, Title = titleToConvert.name};
        }

        public static Teacher ConvertDbTeacherToTeacher(teacher t)
        {
            return new Teacher
            {
                Name = t.name,
                Id = t.idteachers,
                Surname = t.surname,
                Title = t.title.name
            };
        }
    }
}