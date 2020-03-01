using System;
using System.Collections.Generic;

namespace Model
{
    public partial class EventMaster
    {
        public int Id { get; set; }
        public bool? QrCode { get; set; }
        public string QrCodeHash { get; set; }
        public string QrCodeSalt { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual AuthUser User { get; set; }
    }
}
