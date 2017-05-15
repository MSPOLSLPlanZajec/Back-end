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
    public class DegreeController : ApiController
    {
        private DataBase db = new DataBase();
        public IEnumerable<Degree> GetAllDegrees()
        {
            db = db ?? new DataBase();
            var titles = db.getTitles();
            return titles.Select(a => new Degree() { id = a.idtitles, title = a.name }).ToList();

        }
    }
}
