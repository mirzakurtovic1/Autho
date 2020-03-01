using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AuthUser
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AccountCreatingDate { get; set; }
        public int RoleId { get; set; }
        public string QrCode { get; set; }
        public virtual Role Role { get; set; }
        public string Display { get { return FirstName + " " + LastName + "#" + Id; } }
    }
}
