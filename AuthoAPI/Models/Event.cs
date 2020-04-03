using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Enterance = new HashSet<Enterance>();
            Presence = new HashSet<Presence>();
        }

        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventStartingTime { get; set; }
        public DateTime EventEndingTime { get; set; }
        public bool AnyoneCanEnter { get; set; }
        public int UserCanEnterBeforeEventMi { get; set; }
        public int UserCanEnterAfterEventSta { get; set; }
        public int EventTypeId { get; set; }
        public string EventGroupId { get; set; }
        public int? EventMasterId { get; set; }

        public virtual AuthUser EventMaster { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual ICollection<Enterance> Enterance { get; set; }
        public virtual ICollection<Presence> Presence { get; set; }
    }
}
