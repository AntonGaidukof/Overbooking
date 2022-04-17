using System.Collections.Generic;

namespace TLOverbookingApplication.RoomStayCancellation.Entities
{
    public class GetCancellationPrediction
    {
        public long ProviderId { get; set; }

        public IReadOnlyList<RoomStayForPrediction> RoomStays { get; set; }
    }
}
