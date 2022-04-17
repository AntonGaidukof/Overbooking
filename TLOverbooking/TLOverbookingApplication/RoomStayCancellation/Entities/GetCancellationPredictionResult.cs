using System.Collections.Generic;

namespace TLOverbookingApplication.RoomStayCancellation.Entities
{
    public class GetCancellationPredictionResult
    {
        public IReadOnlyList<CancellationPrediction> CancellationPredictions { get; set; }
    }
}
