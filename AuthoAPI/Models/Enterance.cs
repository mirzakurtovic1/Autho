using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class Enterance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? EnteranceActive { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
