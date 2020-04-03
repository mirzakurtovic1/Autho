using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchRequest
{
    public class PresenceSearchRequest
    {
        public bool? hasNotes { get; set; }
        public int? UserId { get; set; }
        public int? EventId { get; set; }
        public bool? FaceRecognized { get; set; }
        public bool? FaceDetected { get; set; }
        public int? EventMasterId { get; set; }

    }
}
