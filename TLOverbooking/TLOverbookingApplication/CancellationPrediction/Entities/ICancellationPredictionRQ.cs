using System;

namespace TLOverbookingApplication.CancellationPrediction.Entities
{
    public interface ICancellationPredictionRQ
    {
        public long RoomStayId { get; }

        public DateTime LastModified { get; }
    }
}
