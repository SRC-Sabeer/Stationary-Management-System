using System.ComponentModel.DataAnnotations;

namespace Stationary_Management_System.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        
    }
}
