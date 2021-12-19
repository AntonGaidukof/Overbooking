using System.Threading.Tasks;
using TLOverbookingApplication.CancellationPrediction.Entities;

namespace TLOverbookingApplication.OverbookingPrediction.Services
{
    public interface ICancellationPredictionService
    {
        public Task<bool> CanBeCancelledAsync( CancellationPredictionRQ cancellationPredictionRQ );
    }
}
