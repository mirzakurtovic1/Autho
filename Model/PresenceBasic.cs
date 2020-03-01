using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class presenceBasic
    {
        public int Id { get; set; }//userId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool AttendingEvent { get; set; }
        public bool HaNotes { get; set; }
        public int presenceId { get; set; }
    }
}
