using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class EventSearchRequest
    {
        public string EventName { get; set; }
        public string EventGroupId { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? EventStartingTime { get; set; }
        public DateTime? EventEndingTime { get; set; }
        public int? EventMasterId { get; set; }
        public int? EventTypeId { get; set; }
        public bool showOnlyFutureEvents { get; set; } = false;
    }
}
