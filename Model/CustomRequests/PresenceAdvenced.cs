﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PresenceAdvenced
    {
        public int Id { get; set; }//userId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool AttendedEvent { get; set; }
        public bool AttendedWholeEvent { get; set; }
        public bool HaNotes { get; set; }
        public byte[] Face { get; set; }
        public byte[] ScannedFace { get; set; }
        public int presenceId { get; set; }
        public bool FaceRecognized { get; set; }
        public bool FaceDetected { get; set; }
        public string Display { get { return FirstName + " " + LastName + "(" + UserName + ")"; } }

    }
}
//PresenceId//UserId//WholeName//Original face//presence face//Attended event// use face 