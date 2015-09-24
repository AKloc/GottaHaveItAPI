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
        public IHttpActionResult Get(string searchQuery)
        {
            //return events;
            using (Contexts.GottaHaveItContext ctx = new Contexts.GottaHaveItContext())
            {
                //var query = from e in ctx.Events
                //            select e;

                var query = ctx.Events
                    .Where(e => e.Description.Contains(searchQuery) || e.Name.Contains(searchQuery))
                    .Include(e => e.Location)
                    //.Include(e => e.)
                    .ToList();

                return Ok(query);
            }


        }

    }
}
