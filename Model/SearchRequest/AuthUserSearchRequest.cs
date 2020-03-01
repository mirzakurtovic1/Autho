using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class AuthUserSearchRequest
    {
        public string qrCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int? RoleId = null;
        public int? UserGroupId = null;
    }
}
