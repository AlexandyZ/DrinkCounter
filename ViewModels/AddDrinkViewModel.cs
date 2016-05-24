using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkCounter.ViewModels
{
    public class AddDrinkViewModel
    {
        //[Required(ErrorMessage = "The amount must be greater then zero !")]
        // [RegularExpression(@"^\d+$", ErrorMessage = "Only positive number")]
        //[RegularExpression(@"^\d+{1,2}?$", ErrorMessage = "Only positive number are allowed.")]
        //[Range(1, int.MaxValue)]
        //[MaxLength(3)]
        //[MinLength(1)]
        //[RegularExpression(@"\d+", ErrorMessage = "Only integers.")]
        [RegularExpression(@"^\$?\d+?$", ErrorMessage = "Only integers.")]
        public int Amount { get; set; }

        public string UserId { get; set; }

        public int TypeId { get; set; }
    }
}
