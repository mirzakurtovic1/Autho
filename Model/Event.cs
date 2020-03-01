using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Event
    {

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

        public virtual EventType EventType { get; set; }



        public string EventStartingTimeShortString { get { return EventStartingTime.ToString("hh:mm");} }
    }
}
