using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkCounter.ViewModels
{
    public class AddDrinkViewModel
    {
        //[MaxLength(3)]
        //[MinLength(1)]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only positive number.")]
        public int Amount { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
    }
}
