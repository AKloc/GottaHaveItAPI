﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GottaHaveItAPI.Models;

namespace GottaHaveItAPI.Contexts
{
    //Seed the database. Only drop the database if the model has changed, though.
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<GottaHaveItContext>//DropCreateDatabaseIfModelChanges<GottaHaveItContext>
    {
        protected GottaHaveItContext context;

        protected override void Seed(GottaHaveItContext context)
        {
            this.context = context;

            //SeedUsers();
            
            SeedLocations();

            SeedEvents();

            SeedChannels();

            SeedChannelMemberships();

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

            var events = new List<Event>
            {
                new Event
                {
                    Name = "Book Sale",
                    Description = "Our school is throwing a fund-raiser, we'd love to see you come out!",
                    LocationID = locations["Clarence High School"],
                    StartDate = DateTime.Parse("8/15/2016 2:00 PM"),
                    EndDate = DateTime.Parse("8/15/2016 2:00 PM")
                },
                new Event
                {
                    Name = "Freshman Orientation",
                    Description = "It's that time of year! We're excited to meet all of our new students for the 2016 school year. The high school will be holding an orientation day for incoming freshman. They will be assigned lockers, given their schedules, and shown where their classrooms are in the building. We look forward to meeting new students and parents!",
                    LocationID = locations["Clarence High School"],
                    StartDate = DateTime.Parse("8/25/2016 10:00 AM"),
                    EndDate = DateTime.Parse("8/25/2016 1:00 PM")
                },
                new Event
                {
                    Name = "Sub Sale",
                    Description = "Help keep our band program strong - volunteers needed for the annual Clarence bands sub sale.",
                    LocationID = locations["Clarence High School"],
                    StartDate = DateTime.Parse("8/29/2016 7:00 AM"),
                    EndDate = DateTime.Parse("8/29/2016 9:00 PM")
                },
                new Event
                {
                    Name = "Discount Spaghetti Night!",
                    Description = "In honor of something something something, Chef's will be offering our (in)famous spaghetti parmesean meals for just 5$ a plate. No coupon required.",
                    LocationID = locations["Chef's Restaurant"],
                    StartDate = DateTime.Parse("8/18/2016 6:00 PM"),
                    EndDate = DateTime.Parse("8/18/2016 10:00 PM")
                },
                new Event
                {
                    Name = "Game 1: Ottawa Senators at Buffalo Sabres",
                    Description = "Tickets are still available at the First Niagara Center box office, etc etc etc",
                    LocationID = locations["First Niagara Center"],
                    StartDate = DateTime.Parse("9/18/2016 7:00 PM"),
                    EndDate = DateTime.Parse("9/18/2016 11:00 PM")
                },
                new Event
                {
                    Name = "Game 6: Toronto Maple Leafs at Buffalo Sabres",
                    Description = "Tickets are still available at the First Niagara Center box office, etc etc etc",
                    LocationID = locations["First Niagara Center"],
                    StartDate = DateTime.Parse("9/21/2016 7:00 PM"),
                    EndDate = DateTime.Parse("9/21/2016 11:00 PM")
                },
                new Event
                {
                    Name = "Game 2: Edmonton Rush at Buffalo Bandits",
                    Description = "B O X ! Tickets are still available at the First Niagara Center box office, etc etc etc",
                    LocationID = locations["First Niagara Center"],
                    StartDate = DateTime.Parse("9/19/2016 7:00 PM"),
                    EndDate = DateTime.Parse("9/19/2016 11:00 PM")
                }
            };

            events.ForEach(e => { e.IsActive = true; context.Events.Add(e); });
            context.SaveChanges();
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
                },
                new Channel
                {
                    Name = "Buffalo Sabres Home Games",
                    Description = "Never miss a home Sabres game!",
                    DateCreated = DateTime.Now
                },
                new Channel
                {
                    Name = "Buffalo Bandits Home Games",
                    Description = "Never miss a home Bandits game!",
                    DateCreated = DateTime.Now
                },
                new Channel
                {
                    Name = "Sabres and Bandits Home Games",
                    Description = "Never miss a game from either the Bills or Bandits!",
                    DateCreated = DateTime.Now
                }
            };

            channels.ForEach(c => { c.IsActive = true; context.Channels.Add(c); });
            context.SaveChanges();
        }

        protected void SeedChannelMemberships()
        {
            // We need to know what the IDs are of the Channels for the foreign key. Populate them into a dictionary.
            var channels = context.Channels.ToDictionary(c => c.Name, c => c.ID);

            // We need to know what the IDs are of the Events for the foreign key. Populate them into a dictionary.
            var events = context.Events.ToDictionary(e => e.Name, e => e.ID);

            var channelMemberships = new List<ChannelMembership>
            {
                // CLARENCE FUNDRAISERS
                new ChannelMembership
                {
                    ChannelID = channels["Fund Raisers"],
                    EventID = events["Sub Sale"]
                },
                new ChannelMembership
                {
                    ChannelID = channels["Fund Raisers"],
                    EventID = events["Book Sale"]
                },

                // BUFFALO SABRES GAMES
                new ChannelMembership
                {
                    ChannelID = channels["Buffalo Sabres Home Games"],
                    EventID = events["Game 1: Ottawa Senators at Buffalo Sabres"]
                },
                new ChannelMembership
                {
                    ChannelID = channels["Buffalo Sabres Home Games"],
                    EventID = events["Game 6: Toronto Maple Leafs at Buffalo Sabres"]
                },

                // BUFFALO BANDITS GAMES
                new ChannelMembership
                {
                    ChannelID = channels["Buffalo Bandits Home Games"],
                    EventID = events["Game 2: Edmonton Rush at Buffalo Bandits"]
                },

                // BUFFALO BILLS AND BANDITS GAMES
                new ChannelMembership
                {
                    ChannelID = channels["Sabres and Bandits Home Games"],
                    EventID = events["Game 2: Edmonton Rush at Buffalo Bandits"]
                },
                new ChannelMembership
                {
                    ChannelID = channels["Sabres and Bandits Home Games"],
                    EventID = events["Game 1: Ottawa Senators at Buffalo Sabres"]
                },
                new ChannelMembership
                {
                    ChannelID = channels["Sabres and Bandits Home Games"],
                    EventID = events["Game 6: Toronto Maple Leafs at Buffalo Sabres"]
                }
            };

            channelMemberships.ForEach(c => { c.IsActive = true; context.ChannelMemberships.Add(c); });
            context.SaveChanges();
        }



    }
}
