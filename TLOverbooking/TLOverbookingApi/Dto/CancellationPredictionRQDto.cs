﻿using System;
using TLOverbookingApplication.CancellationPrediction.Entities;

namespace TLOverbookingApi.Dto
{
    public class CancellationPredictionRQDto : CancellationPredictionRQ
    {
        public long RoomStayId { get; set; }

        public DateTime LastModified { get; set; }
    }
}
