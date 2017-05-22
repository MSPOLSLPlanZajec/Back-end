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
    [Route("time-suggestion/{id}")]
    public class TimeSuggestionController : ApiController
    {
        // GET: api/TimeSuggestion
        public IEnumerable<List<TimeSuggestion>> Get(string id)
        {
            return new List<List<TimeSuggestion>>()
            {
                new List<TimeSuggestion>() { new TimeSuggestion() {StartsAt=1 },new TimeSuggestion() {StartsAt=5 } },
                new List<TimeSuggestion>() { new TimeSuggestion() {StartsAt=5 }},
                new List<TimeSuggestion>() 
            };
        }

       
    }
}
