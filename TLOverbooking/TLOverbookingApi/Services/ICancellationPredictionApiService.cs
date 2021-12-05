using System.Threading.Tasks;
using TLOverbookingApi.Dto;

namespace TLOverbookingApi.Services
{
    public interface ICancellationPredictionApiService
    {
        public Task<CancellationPredictionResultDto> GetCancellationPredicctionResult( CancellationPredictionRQDto cancellationPredictionRQDto );
    }
}
