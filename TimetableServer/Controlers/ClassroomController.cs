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
    public class ClassroomController : ApiController
    {
        private DataBase _db;

        public IEnumerable<Classroom> GetAllClassroms()
        {
            _db = _db ?? new DataBase();
            var titles = _db.getAllClassRooms();
            return titles.Select(Converter.ConvertDbClassroomToClassroom).ToList();
        }
    }
}
