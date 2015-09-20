using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GottaHaveItAPI.Models;

namespace GottaHaveItAPI.Controllers
{
    public class EventsController : ApiController
    {
        Event[] events = new Event[]
        {
            new Event { Id = 1, ChannelId = 1, Name = "TestName 1", Description = "From Controller Test Array", Location = "Location X", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddDays(5) },
            new Event { Id = 2, ChannelId = 1, Name = "TestName 2", Description = "From Controller Test Array", Location = "Location Y", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddDays(5) },
            new Event { Id = 3, ChannelId = 1, Name = "TestName 3", Description = "From Controller Test Array", Location = "Location Z", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddDays(5) }
        };

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


        public IHttpActionResult GetProduct(int id)
        {
            var selectedEvent = events.FirstOrDefault((p) => p.Id == id);
            if (selectedEvent == null)
            {
                return NotFound();
            }
            return Ok(selectedEvent);
        }
    }
}
