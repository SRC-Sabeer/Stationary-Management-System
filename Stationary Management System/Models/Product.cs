using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class Product
    {
        public Product()
        {
            Approveds = new HashSet<Approved>();
            Rejecteds = new HashSet<Rejected>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string Brand { get; set; } = null!;
        public int Weight { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; } = null!;

        public virtual ICollection<Approved> Approveds { get; set; }
        public virtual ICollection<Rejected> Rejecteds { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
