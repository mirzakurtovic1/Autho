using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class AuthUserImage
    {
        public int Id { get; set; }
        public int AuthUserId { get; set; }
        public byte[] AuthUserImage1 { get; set; }

        public virtual AuthUser AuthUser { get; set; }
    }
}
