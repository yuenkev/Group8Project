// Author: Sebastian Villafane Ramos
// Description: User Model

using System.ComponentModel.DataAnnotations;

namespace Group8Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please, enter your First Name")]
        public string? FName { get; set; }
        [Required(ErrorMessage = "Please, enter your Last Name")]
        public string? LName { get; set; }
        [Required(ErrorMessage = "Please, enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please, enter your Phone Number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number in the format 999-999-9999")]
        public string? PNumber { get; set; }
        [Required(ErrorMessage = "Please, enter your Password")]
        public string? Password { get; set; }
    }
}