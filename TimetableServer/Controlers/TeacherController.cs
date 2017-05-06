using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    public class TeacherController : ApiController
    {
        private DataBase db = new DataBase();

        // GET: api/Teacher
        public IEnumerable<Teacher> GetAllTeachers()
        {
            db = db ?? new DataBase();
            return
                convertDBTeachersToTeachers(db.GetAllTeachers());
        }

        private List<Teacher> convertDBTeachersToTeachers(List<teacher> dbTeachers)
        {
            List<Teacher> Teachers = new List<Teacher>();
            foreach (var dbteacher in dbTeachers)
            {
                var t = new Teacher();
                t.name = dbteacher.name;
                t.id = dbteacher.idteachers;
                t.surname = dbteacher.surname;
                t.title = db.getTitle(dbteacher.idtitles).name;
                Teachers.Add(t);
            }
            return Teachers;
        }
    }
}
