using System;
using System.Collections.Generic;

namespace AuthoAPI.Models
{
    public partial class AuthUser
    {
        public AuthUser()
        {
            AuthUserFace = new HashSet<AuthUserFace>();
            AuthUserImage = new HashSet<AuthUserImage>();
            AuthUserUserGroup = new HashSet<AuthUserUserGroup>();
            Event = new HashSet<Event>();
            Presence = new HashSet<Presence>();
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
        public virtual ICollection<AuthUserFace> AuthUserFace { get; set; }
        public virtual ICollection<AuthUserImage> AuthUserImage { get; set; }
        public virtual ICollection<AuthUserUserGroup> AuthUserUserGroup { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Presence> Presence { get; set; }
    }
}
