using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class RoleEnterance
    {
        public int Id { get; set; }
        public DateTime? PermissionAddingDateTime { get; set; }
        public bool? UnlimitedAccess { get; set; }
        public TimeSpan? AccessFromTime { get; set; }
        public TimeSpan? AccessToTime { get; set; }
        public int RoleId { get; set; }
        public int EnteranceId { get; set; }

        public virtual Enterance Enterance { get; set; }
        public virtual Role Role { get; set; }
    }
}
