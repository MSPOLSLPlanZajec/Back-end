using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    [Route("a/{id}")]
    public class TimeSuggestionController : ApiController
    {
        // GET: api/TimeSuggestion
        public IEnumerable<List<TimeSuggestion>> Get(string id)
        {
            return new List<List<TimeSuggestion>>()
            {
                new List<TimeSuggestion>() { new TimeSuggestion() {startsAt=1 },new TimeSuggestion() {startsAt=5 } },
                new List<TimeSuggestion>() { new TimeSuggestion() {startsAt=5 }},
                new List<TimeSuggestion>() 
            };
        }

       
    }
}
