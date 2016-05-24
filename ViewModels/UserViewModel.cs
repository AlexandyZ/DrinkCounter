using System.ComponentModel.DataAnnotations;

namespace DrinkCounter.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [MaxLength(10)]
        [RegularExpression(@"^[a-zA-Z'.\s]{0,20}$", ErrorMessage = "Only letters.")]
        public string Firstname { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^[a-zA-Z'.\s]{0,20}$", ErrorMessage = "Only letters.")]
        public string Lastname { get; set; }

        // [MaxLength(30)]
        public string Address { get; set; }

        //[MaxLength(3)]
        //[MinLength(1)]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only positive number.")]
        public int Age { get; set; }

        [MaxLength(1)]
        [RegularExpression(@"^[a-zA-Z'.\s]{1}$", ErrorMessage = "Only 1 letter.")]
        public string Gender { get; set; }

        //public string Password { get; set; }
    }
}
