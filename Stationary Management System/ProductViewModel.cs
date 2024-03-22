using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Stationary_Management_System.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

      

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

       

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = " Weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Display(Name = " Stock")]
        public int Stock { get; set; }

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
