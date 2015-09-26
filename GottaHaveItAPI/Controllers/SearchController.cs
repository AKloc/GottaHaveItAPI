using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using GottaHaveItAPI.Models;

namespace GottaHaveItAPI.Controllers
{
    public class SearchController : ApiController
    {

        [HttpGet]
        [Route("api/search/{searchQuery}")]
        public IHttpActionResult Get(string searchQuery)
        {
            //return events;
            using (Contexts.GottaHaveItContext ctx = new Contexts.GottaHaveItContext())
            {
                var eventQuery = ctx.Events
                    .Where(e => e.Description.Contains(searchQuery) || e.Name.Contains(searchQuery))
                    .Include(e => e.Location)
                    //.Include(e => e.)
                    .ToList();

                var channelQuery = ctx.Channels
                    .Where(c => c.Description.Contains(searchQuery) || c.Name.Contains(searchQuery))
                    //.Include(e => e.)
                    .ToList();

                var query = new
                {
                    eventResults = eventQuery,
                    channelResults = channelQuery
                };

                return Ok(query);
            }


        }

        [HttpGet]
        [Route("api/search/")]
        public IHttpActionResult Get()
        {
            //return events;
            using (Contexts.GottaHaveItContext ctx = new Contexts.GottaHaveItContext())
            {
                var query = ctx.Events
                    .Include(e => e.Location)
                    //.Include(e => e.)
                    .ToList();

                return Ok(query);
            }
        }

    }
}
