using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class AuthUserFace
    {
        public int Id { get; set; }
        public int AuthUserId { get; set; }
        public byte[] Face { get; set; }

        public virtual AuthUser AuthUser { get; set; }
    }
}
