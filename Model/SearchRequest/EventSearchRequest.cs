using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class EventSearchRequest
    {
        public string EventGroupId { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? EventStartingTime { get; set; }
        public DateTime? EventEndingTime { get; set; }
    }
}
