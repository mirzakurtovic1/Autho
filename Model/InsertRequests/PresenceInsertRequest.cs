using System;
using System.Collections.Generic;
using System.Text;

namespace Model.InsertRequests
{
    public class PresenceInsertRequest
    {
        public DateTime? PresenceCreatingDateTime { get; set; }
        public DateTime? PresenceAttendingDateTime { get; set; }
        public bool? AttendedWholeEvent { get; set; }
        public DateTime? PresenceLeavingDateTime { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public byte[] Image { get; set; }
        public bool FaceRecognized { get; set; }
        public bool FaceDetected { get; set; }
    }
}
