namespace DrinkCounter.Models
{
    public class TeamMember
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public bool Activated { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual Team Team { get; set; }
    }
}
