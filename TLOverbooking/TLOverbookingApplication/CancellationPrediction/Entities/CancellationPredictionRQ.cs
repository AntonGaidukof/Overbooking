using System.Collections.Generic;

namespace TLOverbookingApplication.CancellationPrediction.Entities
{
    public class CancellationPredictionRQ
    {
        public IReadOnlyList<long> RoomStayIds { get; set; }
    }
}
