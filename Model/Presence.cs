using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Presence
    {
        public int Id { get; set; }
        public DateTime? PresenceCreatingDateTime { get; set; }
        public DateTime? PresenceAttendingDateTime { get; set; }
        public bool? AttendedWholeEvent { get; set; }
        public DateTime? PresenceLeavingDateTime { get; set; }
        public string Notes { get; set; }
        public bool hasNotes { get { return Notes!=null; } }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public byte[] Image { get; set; }

        public virtual Event Event { get; set; }
        public virtual AuthUser User { get; set; }
    }
}
