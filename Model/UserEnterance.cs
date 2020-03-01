using System;
using System.Collections.Generic;

namespace Model
{
    public partial class UserEnterance
    {
        public int Id { get; set; }
        public DateTime? PermissionAddingTime { get; set; }
        public bool? UnlimitedAccess { get; set; }
        public TimeSpan? AccessFromTime { get; set; }
        public TimeSpan? AccessToTime { get; set; }
        public int UserId { get; set; }
        public int EnteranceId { get; set; }

        public virtual Enterance Enterance { get; set; }
        public virtual AuthUser User { get; set; }
    }
}
