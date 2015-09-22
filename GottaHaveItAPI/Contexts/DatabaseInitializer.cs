using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GottaHaveItAPI.Models;

namespace GottaHaveItAPI.Contexts
{
    //Seed the database. Only drop the database if the model has changed, though.
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GottaHaveItContext>
    {
        protected GottaHaveItContext context;

        protected override void Seed(GottaHaveItContext context)
        {
            this.context = context;

            //SeedUsers();
            
            SeedLocations();

            SeedEvents();

            SeedChannels();

            //SeedChannelMemberships();

        }


        protected void SeedLocations()
        {
            var locations = new List<Location>
            {
                new Location {Name="Clarence High School", AddrLine1= "9625 Main St", City="Clarence", State="NY", ZipCode="14031"},
                new Location {Name="Chef's Restaurant", AddrLine1= "291 Seneca St", City="Buffalo", State="NY", ZipCode="14204"},
                new Location {Name="First Niagara Center", AddrLine1= "One Seneca Tower", City="Buffalo", State="NY", ZipCode="14203"}
            };

            locations.ForEach(l => { l.IsActive = true; context.Locations.Add(l); });
            context.SaveChanges();
        }

        protected void SeedEvents()
        {
            // We need to know what the IDs are of the locations for the foreign key. Populate them into a dictionary.
            var locations = context.Locations.ToDictionary(l => l.Name, l => l.ID);

            // We need to know what the IDs are of the Channels for the foreign key. Populate them into a dictionary.
            var channels = context.Channels.ToDictionary(c => c.Name, c => c.ID);

            var events = new List<Event>
            {
                new Event
                {
                    Name = "Book Sale",
                    Description = "Our school is throwing a fund-raiser, we'd love to see you come out!",
                    LocationID = locations["Clarence High School"],
                    StartDate = DateTime.Parse("8/15/2016 2:00 PM"),
                    EndDate = DateTime.Parse("8/15/2016 2:00 PM")
                }
            };
        }

        protected void SeedChannels()
        {
            var channels = new List<Channel>
            {
                new Channel
                {
                    Name = "Fund Raisers",
                    Description = "This channel contains all of Clarence High School's fund raising activities. Subscribe and help keep our school at the top!",
                    DateCreated = DateTime.Now
                }
            };

            channels.ForEach(c => { c.IsActive = true; context.Channels.Add(c); });
            context.SaveChanges();
        }
    }
}
