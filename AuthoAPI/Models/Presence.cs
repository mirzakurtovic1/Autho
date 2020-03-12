using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class Presence
    {
        public Presence()
        {
            AuthUserFace = new HashSet<AuthUserFace>();
        }

        public int Id { get; set; }
        public DateTime? PresenceCreatingDateTime { get; set; }
        public DateTime? PresenceAttendingDateTime { get; set; }
        public bool? AttendedWholeEvent { get; set; }
        public DateTime? PresenceLeavingDateTime { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public byte[] Image { get; set; }
        public bool FaceRecognized { get; set; }
        public bool FaceDetected { get; set; }

        public virtual Event Event { get; set; }
        public virtual AuthUser User { get; set; }
        public virtual ICollection<AuthUserFace> AuthUserFace { get; set; }
    }
}
