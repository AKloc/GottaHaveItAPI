using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GottaHaveItAPI.Models
{
    class ChannelMembership
    {
        public int ID { get; set; }
        public int ChannelID { get; set; }
        public int EventID { get; set; }
        public bool IsActive { get; set; }


        public virtual Event Event { get; set; }
        public virtual Channel Channel { get; set; }
    }
}
