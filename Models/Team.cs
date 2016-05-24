using System;
using System.Collections.Generic;

namespace DrinkCounter.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<TeamMember> TeamMember { get; set; }
    }
}
