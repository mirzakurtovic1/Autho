using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DateBasic
    {
        public DateTime Date { get; set; }

        public string Display { get { return Date.ToShortDateString() + " - " + Date.DayOfWeek; } }
    }
}
