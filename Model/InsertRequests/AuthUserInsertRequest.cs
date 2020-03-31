using System;
using System.Collections.Generic;
using System.Text;

namespace Model.InsertRequests
{
    public class AuthUserInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AccountCreatingDate { get; set; }
        public int RoleId { get; set; }
        public string QrCode { get; set; }

    }
}
