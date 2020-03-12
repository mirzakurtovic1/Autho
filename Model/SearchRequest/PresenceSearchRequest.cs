﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class PresenceSearchRequest
    {
        public bool? hasNotes = null;
        public int? UserId = null;
        public int? EventId = null;
        public bool? FaceRecognized { get; set; }
        public bool? FaceDetected { get; set; }
    }
}
