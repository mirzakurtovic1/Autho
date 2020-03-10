using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DateBasic
    {
        public int? eventId { get; set; }

        public DateTime Date { get; set; }

        public string Display { get { return Date.ToShortDateString() + " - " + Date.DayOfWeek; } }
    }
}
