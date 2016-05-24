using System.Collections.Generic;

namespace DrinkCounter.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        
        public ICollection<TeamMember> TeamMember { get; internal set; }
        public ICollection<DrinkCount> DrinkCount { get; internal set; }
    }
}
