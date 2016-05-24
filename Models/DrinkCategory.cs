using System.Collections.Generic;

namespace DrinkCounter.Models
{
    public class DrinkCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DrinkType> DrinkType { get; set; }
    }
}
