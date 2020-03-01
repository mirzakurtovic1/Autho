using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class AuthUser
    {
        public AuthUser()
        {
            AuthUserUserGroup = new HashSet<AuthUserUserGroup>();
            EventMaster = new HashSet<EventMaster>();
            Presence = new HashSet<Presence>();
            UserEnterance = new HashSet<UserEnterance>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AccountCreatingDate { get; set; }
        public int RoleId { get; set; }
        public string QrCode { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AuthUserUserGroup> AuthUserUserGroup { get; set; }
        public virtual ICollection<EventMaster> EventMaster { get; set; }
        public virtual ICollection<Presence> Presence { get; set; }
        public virtual ICollection<UserEnterance> UserEnterance { get; set; }
    }
}
