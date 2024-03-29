using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
