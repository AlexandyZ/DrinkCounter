using System;
namespace DrinkCounter.Models
{ 
    public class DrinkCount
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public string UserId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual DrinkType DrinkType { get; set; }
    }
}
