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
        private DataBase db = new DataBase();

        public IEnumerable<Group> GetAllGroups()
        {
            db = db ?? new DataBase();
            return
                populateSubGroups(convertDBGroupsToGroups(db.getGroupsWithParentGroupId(null)));
        }

        private List<Group> convertDBGroupsToGroups(List<@group> dbGroups)
        {
            List<Group> Groups = new List<Group>();
            foreach (var dbGroup in dbGroups)
            {
                var gr = new Group();
                gr.name = dbGroup.name;
                gr.id = dbGroup.idgroups;
                gr.groups = new List<Group>();
                Groups.Add(gr);
            }
            return Groups;
        }

        private List<Group> populateSubGroups(List<Group> baseGroup)
        {
            if (baseGroup.Count == 0)
                return baseGroup;
            foreach (var group in baseGroup)
            {
                group.groups = populateSubGroups(convertDBGroupsToGroups(db.getGroupsWithParentGroupId(group.id)));
            }
            return baseGroup;
        }
    }
}
