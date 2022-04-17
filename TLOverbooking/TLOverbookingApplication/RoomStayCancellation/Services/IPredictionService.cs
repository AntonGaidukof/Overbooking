using TLOverbookingApplication.RoomStayCancellation.Entities;

namespace TLOverbookingApplication.RoomStayCancellation.Services
{
    public interface IPredictionService
    {
        public GetCancellationPredictionResult GetCancellationPrediction( GetCancellationPrediction request );
    }
}
