using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class AuthUserUserGroup
    {
        public int UserGroupId { get; set; }
        public int AuthUserId { get; set; }
        public int Id { get; set; }

        public virtual AuthUser AuthUser { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
