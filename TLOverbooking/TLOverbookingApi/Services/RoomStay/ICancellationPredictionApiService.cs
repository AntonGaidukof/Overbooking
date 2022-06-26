using System.Threading.Tasks;
using TLOverbookingApi.Dto.CancellationPrediction.RoomStay;

namespace TLOverbookingApi.Services.RoomStay
{
    public interface ICancellationPredictionApiService
    {
        public Task StartLearningAsync( ModelStartLearningDto modelStartLearningDto );

        public CancellationPredictionsDto GetCancellationPredictions( GetCancellationPredictionDto request );

        public Task CreateDataView( long providerId );
    }
}
