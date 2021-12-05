using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto;
using TLOverbookingApi.Services;

namespace TLOverbookingApi.Controllers
{
    [Route( "api/cancellation-prediction" )]
    public class CancellationPredictionController : Controller
    {
        private readonly ICancellationPredictionApiService _cancellationPredictionApiService;

        public CancellationPredictionController( ICancellationPredictionApiService cancellationPredictionApiService )
        {
            _cancellationPredictionApiService = cancellationPredictionApiService;
        }

        [HttpGet, Route( "" )]
        public async Task<IActionResult> GetCancellationPrediction( CancellationPredictionRQDto cancellationPredictionDto )
        {
            CancellationPredictionResultDto cancellationPredictionResultDto = await _cancellationPredictionApiService.GetCancellationPredicctionResult( cancellationPredictionDto );
            
            return Ok( cancellationPredictionResultDto );
        }
    }
}
