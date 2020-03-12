using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class AuthUserFaceSearchRequest
    {
        public int AuthUserId { get; set; }
        public bool? onlyOne { get; set; }
        public int? PresenceId { get; set; }

    }
}
