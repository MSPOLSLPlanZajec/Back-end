using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TeacherController : ApiController
    {
        private DataBase _db;

        // GET: api/Teacher
        public IEnumerable<Teacher> GetAllTeachers()
        {
            _db = _db ?? new DataBase();
            return _db.GetAllTeachers().Select(Converter.ConvertDbTeacherToTeacher);
        }
    }
}
