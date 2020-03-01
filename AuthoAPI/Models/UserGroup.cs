using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            AuthUserUserGroup = new HashSet<AuthUserUserGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AuthUserUserGroup> AuthUserUserGroup { get; set; }
    }
}
