using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class Enterance
    {
        public Enterance()
        {
            RoleEnterance = new HashSet<RoleEnterance>();
            UserEnterance = new HashSet<UserEnterance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? EnteranceActive { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<RoleEnterance> RoleEnterance { get; set; }
        public virtual ICollection<UserEnterance> UserEnterance { get; set; }
    }
}
