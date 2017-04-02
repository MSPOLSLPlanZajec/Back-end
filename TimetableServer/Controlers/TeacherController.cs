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
        // GET: api/Teacher
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return new List<Teacher>()
            {
                new Teacher() { id="1",name="Jan",surname="Kowalski",title="dr inz"},
                new Teacher() { id="2",name="Janina",surname="Kowalska",title="dr hab inz"},


            };
        }

        

      
    }
}
