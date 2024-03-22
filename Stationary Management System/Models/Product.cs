using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
<<<<<<< HEAD
        public int Price { get; set; }


  
        public string Brand { get; set; } = null!;
      
        public int Weight { get; set; }
        public int Stock { get; set; }
=======
        public long Price1 { get; set; }
        public long Price2 { get; set; }
        public long Price3 { get; set; }
        public string Warranty { get; set; } = null!;
        public string Application { get; set; } = null!;
        public string PlaceOfOrigin { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Function { get; set; } = null!;
        public long PackageWeight { get; set; }
>>>>>>> d9b6ea03deb0e4bcaeb7a0a1a5c013420405da0e
        public string? Image { get; set; }
    }
}
