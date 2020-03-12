using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class AuthUserFace
    {
        public int Id { get; set; }
        public int AuthUserId { get; set; }
        public byte[] Face { get; set; }
        public int? PresenceId { get; set; }
        public virtual Presence Presence { get; set; }
        //public virtual AuthUser AuthUser { get; set; }
    }
}
