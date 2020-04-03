using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            AuthUser = new HashSet<AuthUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? CanCreateEvent { get; set; }
        public bool? CanAttendEvent { get; set; }

        public virtual ICollection<AuthUser> AuthUser { get; set; }
    }
}
