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
    //[Route("api/[controller]")]
    public class EventsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllEvents()
        {
            //return events;
            using (Contexts.EntitiesDBConnection ctx = new Contexts.EntitiesDBConnection())
            {
                //var query = from e in ctx.Events
                   //         select e;

                var query = ctx.Events.ToList();

                return Ok(query);
            }

            
        }
        
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            using (Contexts.EntitiesDBConnection ctx = new Contexts.EntitiesDBConnection())
            {
                //var query = from e in ctx.Events
                //         select e;

                var query = ctx.Events.FirstOrDefault((p) => p.EventId == id);

                if(query == null)
                {
                    return NotFound();
                }

                return Ok(query);
            }
        }
    }
}
