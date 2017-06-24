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
    public class LessonTypesController : ApiController
    {
        private DataBase _db;

        public IEnumerable<LessonType> GetAll()
        {
            _db = _db ?? new DataBase();
            return _db.getAllCRTypes().Select(Converter.ConvertClassroomTypeToLessonType);
        } 
    }
}
