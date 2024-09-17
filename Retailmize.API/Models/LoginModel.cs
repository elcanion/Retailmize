using System.ComponentModel.DataAnnotations;

namespace Retailmize.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "{0} must be at least {2} an max {1} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
