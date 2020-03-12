using System;
using System.Collections.Generic;
using System.Text;

namespace Model.InsertRequests
{
    public class AuthUserFaceInsertRequest
    {
        public int AuthUserId { get; set; }
        public byte[] Face { get; set; }
        public virtual AuthUser AuthUser { get; set; }
        public int? PresenceId { get; set; }
        public virtual Presence Presence { get; set; }
    }
}
