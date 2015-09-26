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
    public class ChannelsController : ApiController
    {
        [HttpGet]
        [Route("api/events/")]
        public IHttpActionResult Get()
        {
            using (Contexts.GottaHaveItContext ctx = new Contexts.GottaHaveItContext())
            {
                var query = ctx.Channels
                    .Include(c => c.Events)
                    //.Include(e => e.)
                    .ToList();

                return Ok(query);
            }

        }

        [HttpGet]
        [Route("api/channels/{id}")]
        public IHttpActionResult Get(int id)
        {
            using (Contexts.GottaHaveItContext ctx = new Contexts.GottaHaveItContext())
            {
                //var query = from e in ctx.Events
                //         select e;

                var query = ctx.Channels.FirstOrDefault((c) => c.ID == id);

                if (query == null)
                {
                    return NotFound();
                }

                return Ok(query);
            }
        }
    }
}
