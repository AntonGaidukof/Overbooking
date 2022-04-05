using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingApplication.CancellationPrediction.Entities;

namespace TLOverbookingApplication.OverbookingPrediction.Services
{
    public interface ICancellationPredictionService
    {
        public Task<Dictionary<long, bool>> GetCancellationPredictionsAsync( CancellationPredictionRQ cancellationPredictionRQ );
    }
}
