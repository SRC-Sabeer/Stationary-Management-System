using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Country { get; set; } 
        public string Notes { get; set; } = null!;
        public int Quantity { get; set; }
        public int Total { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
