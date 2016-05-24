using System;

namespace DrinkCounter.ViewModels
{
    public class TeamViewModel
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool Activated { get; set; }
        public int Size { get; set; }
        public DateTime Date { get; set; }
    }
}
