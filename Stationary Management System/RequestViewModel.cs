using System;
using System.ComponentModel.DataAnnotations;

namespace Stationary_Management_System.Models
{
    public class RequestViewModel
    {
        [Required(ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter the quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Note { get; set; }
    }
}
