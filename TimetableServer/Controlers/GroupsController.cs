using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TimetableServer.Models;
using TimetableServer;

namespace TimetableServer.Controlers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GroupsController : ApiController
    {
        private DataBase _db;

        public IEnumerable<Group> GetAllGroups()
        {
            _db = _db ?? new DataBase();
            return
                PopulateSubGroups(Converter.ConvertDbGroupsToGroups(_db.getGroupsWithParentGroupId(null)));
        }

        private List<Group> PopulateSubGroups(List<Group> baseGroup)
        {
            if (baseGroup.Count == 0)
                return baseGroup;
            foreach (var group in baseGroup)
            {
                group.groups = PopulateSubGroups(Converter.ConvertDbGroupsToGroups(_db.getGroupsWithParentGroupId(group.id)));
            }
            return baseGroup;
        }
    }
}
