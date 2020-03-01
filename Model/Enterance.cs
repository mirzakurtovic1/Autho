using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Enterance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? EnteranceActive { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        //public virtual ICollection<RoleEnterance> RoleEnterance { get; set; }
        //public virtual ICollection<UserEnterance> UserEnterance { get; set; }
    }
}
