﻿using System;

namespace TLOverbookingApplication.RoomStayFactExtraction.Entities
{
    public class RoomStayFactExtractionRQ
    {
        public long ProviderId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
