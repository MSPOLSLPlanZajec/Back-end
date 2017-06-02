using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableServer
{
    public class DataBase
    {
        private TimeTableEntities database;

        public DataBase()
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

        public List<classroom> getAllClassRooms()
        {
            return database.classrooms.ToList();
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

        public List<croomtype> getAllCRTypes()
        {
            return database.croomtypes.ToList();
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

        public List<day> getAllDays()
        {
            return database.days.ToList();
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

        public List<department> getAllDepartments()
        {
            return database.departments.ToList();
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

        public List<faculty> getAllFaculties()
        {
            return database.faculties.ToList();
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

        public List<group> getGroupsWithParentGroupId(string id)
        {
            List<group> groupsList = new List<group>();
            groupsList.AddRange(database.groups.Where(gr => gr.idsupergroup == id));
            return groupsList;
        }

        public group getGroup(string id)
        {
            group gr = database.groups.First(data => data.idgroups == id);
            return gr;
        }

        public List<group> getAllGroups()
        {
            return database.groups.ToList();
        }

        public List<group> getSubgroups(string id)
        {
            return database.groups.First(data => data.idgroups == id).groups1.ToList();
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

        public List<lesson> getAllLessons()
        {
            return database.lessons.ToList();
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

        public List<semester> getAllSemesters()
        {
            return database.semesters.ToList();
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
        public List<subject> getAllSubjects()
        {
            return database.subjects.ToList<subject>();

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

        public List<teacher> GetAllTeachers()
        {
            return database.teachers.ToList();
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

        public List<teaching> getAllTeaching()
        {
            return database.teachings.ToList();
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
        public List<title> getTitles()
        {
            var tit = database.titles.ToList<title>();
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

        #region
        public bool existsAccount(string username, string encryptedPassword)
        {
            int number = database.accounts.Where(data => data.username == username && data.encryptedpass == encryptedPassword).Count();
            return number != 0;
        }
        #endregion
        ~DataBase()
        {

        }
    }
}