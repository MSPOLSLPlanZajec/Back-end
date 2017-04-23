﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer
{
    public class DataBase
    {
        private TimeTableEntities database;

        DataBase()
        {
            database = new TimeTableEntities();
        }

        #region CR functions
        public void insertClassRoom(ref classroom cr)
        {
            database.classrooms.Add(cr);
            database.SaveChanges();
        }

        public classroom getClassRoom(string id)
        {
            classroom cr = database.classrooms.First(data => data.idclassrooms == id);
            return cr;
        }

        public void updateClassRoom(string id, classroom cr)
        {
            classroom dbcr = database.classrooms.First(data => data.idclassrooms == id);
            dbcr = cr;
            database.SaveChanges();
        }

        public void deleteClassRoom(string id)
        {
            classroom cr = database.classrooms.First(data => data.idclassrooms == id);

            database.classrooms.Remove(cr);
        }
        #endregion

        #region CRType functions
        public void insertCRType(ref croomtype crt)
        {
            database.croomtypes.Add(crt);
            database.SaveChanges();
        }

        public croomtype getCRType(string id)
        {
            croomtype crt = database.croomtypes.First(data => data.idcroomtype == id);
            return crt;
        }

        public void updateCRType(string id, croomtype crt)
        {
            croomtype dbcrt = database.croomtypes.First(data => data.idcroomtype == id);
            dbcrt = crt;
            database.SaveChanges();
        }

        public void deleteCRType(string id)
        {
            croomtype crt = database.croomtypes.First(data => data.idcroomtype == id);

            database.croomtypes.Remove(crt);
        }
        #endregion

        #region Days functions
        public void insertDays(ref day d)
        {
            database.days.Add(d);
            database.SaveChanges();
        }

        public day getDays(string id)
        {
            day d = database.days.First(data => data.iddays == id);
            return d;
        }

        public void updateDays(string id, day d)
        {
            day dbd = database.days.First(data => data.iddays == id);
            dbd = d;
            database.SaveChanges();
        }

        public void deleteDays(string id)
        {
            day d = database.days.First(data => data.iddays == id);

            database.days.Remove(d);
        }
        #endregion

        #region Department functions
        public void insertDepartment(ref department d)
        {
            database.departments.Add(d);
            database.SaveChanges();
        }

        public department getDepartment(string id)
        {
            department d = database.departments.First(data => data.iddepartment == id);
            return d;
        }

        public void updateDepartment(string id, department d)
        {
            department dbd = database.departments.First(data => data.iddepartment == id);
            dbd = d;
            database.SaveChanges();
        }

        public void deleteDepartment(string id)
        {
            department d = database.departments.First(data => data.iddepartment == id);

            database.departments.Remove(d);
        }
        #endregion

        #region Faculty functions
        public void insertFaculty(ref faculty f)
        {
            database.faculties.Add(f);
            database.SaveChanges();
        }

        public faculty getFaculty(string id)
        {
            faculty f = database.faculties.First(data => data.idfaculty == id);
            return f;
        }

        public void updateFaculty(string id, faculty f)
        {
            faculty dbf = database.faculties.First(data => data.idfaculty == id);
            dbf = f;
            database.SaveChanges();
        }

        public void deleteFaculty(string id)
        {
            faculty f = database.faculties.First(data => data.idfaculty == id);

            database.faculties.Remove(f);
        }
        #endregion

        #region Group functions
        public void insertGroup(ref group gr)
        {
            database.groups.Add(gr);
            database.SaveChanges();
        }

        public group getGroup(string id)
        {
            group gr = database.groups.First(data => data.idgroups == id);
            return gr;
        }

        public void updateGroup(string id, group gr)
        {
            group dbgr = database.groups.First(data => data.idgroups == id);
            dbgr = gr;
            database.SaveChanges();
        }

        public void deleteGroup(string id)
        {
            group gr = database.groups.First(data => data.idgroups == id);

            database.groups.Remove(gr);
        }
        #endregion

        #region Lesson functions
        public void insertLesson(ref lesson l)
        {
            database.lessons.Add(l);
            database.SaveChanges();
        }

        public lesson getLesson(string id)
        {
            lesson l = database.lessons.First(data => data.idlessons == id);
            return l;
        }

        public void updateLesson(string id, lesson l)
        {
            lesson dbl = database.lessons.First(data => data.idlessons == id);
            dbl = l;
            database.SaveChanges();
        }

        public void deleteLesson(string id)
        {
            lesson l = database.lessons.First(data => data.idlessons == id);

            database.lessons.Remove(l);
        }
        #endregion

        #region Semester functions
        public void insertSemester(ref semester sem)
        {
            database.semesters.Add(sem);
            database.SaveChanges();
        }

        public semester getSemester(string id)
        {
            semester sem = database.semesters.First(data => data.idsemesters == id);
            return sem;
        }

        public void updateSemester(string id, semester sem)
        {
            semester dbsem = database.semesters.First(data => data.idsemesters == id);
            dbsem = sem;
            database.SaveChanges();
        }

        public void deleteSemester(string id)
        {
            semester sem = database.semesters.First(data => data.idsemesters == id);

            database.semesters.Remove(sem);
        }
        #endregion

        #region Subject functions
        public void insertSubject(ref subject sub)
        {
            database.subjects.Add(sub);
            database.SaveChanges();
        }

        public subject getSubject(string id)
        {
            subject sub = database.subjects.First(data => data.idsubjects == id);
            return sub;
        }

        public void updateSubject(string id, subject sub)
        {
            subject dbsub = database.subjects.First(data => data.idsubjects == id);
            dbsub = sub;
            database.SaveChanges();
        }

        public void deleteSubject(string id)
        {
            subject sub = database.subjects.First(data => data.idsubjects == id);

            database.subjects.Remove(sub);
        }
        #endregion

        #region Teacher functions
        public void insertTeacher(ref teacher tchr)
        {
            database.teachers.Add(tchr);
            database.SaveChanges();
        }

        public teacher getTeacher(string id)
        {
            teacher tchr = database.teachers.First(data => data.idteachers == id);
            return tchr;
        }

        public void updateTeacher(string id, teacher tchr)
        {
            teacher dbtchr = database.teachers.First(data => data.idteachers == id);
            dbtchr = tchr;
            database.SaveChanges();
        }

        public void deleteTeacher(string id)
        {
            teacher tchr = database.teachers.First(data => data.idteachers == id);

            database.teachers.Remove(tchr);
        }
        #endregion

        #region Teaching functions
        public void insertTeaching(ref teaching tch)
        {
            database.teachings.Add(tch);
            database.SaveChanges();
        }

        public teaching getTeaching(string id)
        {
            teaching tch = database.teachings.First(data => data.idmain == id);
            return tch;
        }

        public void updateTeaching(string id, teaching tch)
        {
            teaching dbtch = database.teachings.First(data => data.idmain == id);
            dbtch = tch;
            database.SaveChanges();
        }

        public void deleteTeaching(string id)
        {
            teaching tch = database.teachings.First(data => data.idmain == id);

            database.teachings.Remove(tch);
        }
        #endregion

        #region Title functions
        public void insertTitle(ref title tit)
        {
            database.titles.Add(tit);
            database.SaveChanges();
        }

        public title getTitle(string id)
        {
            title tit = database.titles.First(data => data.idtitles == id);
            return tit;
        }

        public void updateTitle(string id, title tit)
        {
            title dbtit = database.titles.First(data => data.idtitles == id);
            dbtit = tit;
            database.SaveChanges();
        }

        public void deleteTitle(string id)
        {
            title tit = database.titles.First(data => data.idtitles == id);

            database.titles.Remove(tit);
        }
        #endregion

        ~DataBase()
        {
            
        }
    }
}