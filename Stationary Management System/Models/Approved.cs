using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class Approved
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime RequestedDate { get; set; }
        
        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;


    }
}
