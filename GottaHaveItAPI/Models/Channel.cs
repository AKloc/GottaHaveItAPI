using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GottaHaveItAPI.Models
{
    class Channel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastEditted { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        //Created By?
        //Last Editted By?
    }
}
