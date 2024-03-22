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

<<<<<<< HEAD
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

      
=======
        [Required(ErrorMessage = "Price1 is required")]
        public long Price1 { get; set; }

        [Required(ErrorMessage = "Price1 is required")]
        public long Price2 { get; set; }

        [Required(ErrorMessage = "Price1 is required")]
        public long Price3 { get; set; }

        [Required(ErrorMessage = "Warranty is required")]
        public string Warranty { get; set; }

        [Required(ErrorMessage = "Application is required")]
        public string Application { get; set; }

        [Required(ErrorMessage = "PlaceOfOrigin is required")]
        public string PlaceOfOrigin { get; set; }
>>>>>>> d9b6ea03deb0e4bcaeb7a0a1a5c013420405da0e

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

<<<<<<< HEAD
       

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = " Weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Display(Name = " Stock")]
        public int Stock { get; set; }
=======
        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Function is required")]
        public string Function { get; set; }

        [Required(ErrorMessage = "PackageWeight is required")]
        [Display(Name = "Package Weight")]
        public long PackageWeight { get; set; }
>>>>>>> d9b6ea03deb0e4bcaeb7a0a1a5c013420405da0e

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
