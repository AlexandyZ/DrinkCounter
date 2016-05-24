using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkCounter.Models
{
    public class DrinkType
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DrinkTypeId { get; set; }
        public string DrinkName { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public int DrinkCategoryId { get; set; }

        public virtual ICollection<DrinkCount> DrinkCount { get; set; }
        public virtual DrinkCategory DrinkCategory { get; set; }
    }
}