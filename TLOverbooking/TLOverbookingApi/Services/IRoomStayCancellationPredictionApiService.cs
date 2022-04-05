using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayCancellationPrediction;

namespace TLOverbookingApi.Services
{
    public interface IRoomStayCancellationPredictionApiService
    {
        public Task StartLearningAsync( ModelStartLearningDto modelStartLearningDto );
    }
}
