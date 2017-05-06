using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    public class DegreeController : ApiController
    {
        public IEnumerable<Degree> GetAllDegrees()
        {
            DataBase db = new DataBase();
            var titles = db.getTitles();
            return titles.Select(a => new Degree() { id=a.idtitles,title=a.name}).ToList();

            //return new List<Degree>()
            //{
            //   new Degree() {id=title.idtitles,title=title.name }               
            //};
        }
    }
}
