using System;

namespace TLOverbookingApplication.CancellationPrediction.Entities
{
    public class CancellationPredictionRQ
    {
        public long RoomStayId { get; }

        public DateTime LastModified { get; }
    }
}
