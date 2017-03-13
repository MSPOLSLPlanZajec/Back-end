using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    public class GroupsController : ApiController
    {
        public IEnumerable<Group> GetAllGroups()
        {
            return new List<Group>()
            {
                new Group()
                {
                    id = "XD", name = "Informatyka", groups = new List<Group>()
                    {
                        new Group() { id = "XDNO", name = "Semestr 1", groups = null},
                        new Group() { id = "XDBEKA", name = "Semestr 2", groups = null}
                    }
                }
            };
        }

        public IEnumerable<Group> GetGroupsForIdAndSomething(int id, string type)
        {
            return new List<Group>()
            {
                new Group()
                {
                    id = "XD", name = "InformatykaModzno", groups = new List<Group>()
                    {
                        new Group() { id = "XDNO", name = "Semestr 1", groups = null},
                        new Group() { id = "XDBEKA", name = "Semestr 2", groups = null}
                    }
                }
            };
        }
    }
}
