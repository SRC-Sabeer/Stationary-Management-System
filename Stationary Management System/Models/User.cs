using System;
using System.Collections.Generic;

namespace Stationary_Management_System.Models
{
    public partial class User
    {
        public User()
        {
            Approveds = new HashSet<Approved>();
            Rejecteds = new HashSet<Rejected>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Approved> Approveds { get; set; }
        public virtual ICollection<Rejected> Rejecteds { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
