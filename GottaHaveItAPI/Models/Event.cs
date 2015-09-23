using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GottaHaveItAPI.Models
{
    class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationID { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastEditted { get; set; }
        public bool IsActive { get; set; }

        public virtual Location Location { get; set; }

    }
}
