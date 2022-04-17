using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.CancellationPrediction.RoomStay;
using TLOverbookingApi.Services.RoomStay;

namespace TLOverbookingApi.Controllers
{
    [Route( "api/cancellation-prediction" )]
    public class CancellationPredictionController : Controller
    {
        private readonly ICancellationPredictionApiService _cancellationPredictionApiService;

        public CancellationPredictionController( ICancellationPredictionApiService roomStayCancellationPredictionApiService )
        {
            _cancellationPredictionApiService = roomStayCancellationPredictionApiService;
        }

        [HttpPost, Route( "room-stay/start-learning" )]
        public async Task<IActionResult> StartLearningAsync( [FromBody] ModelStartLearningDto request )
        {
            await _cancellationPredictionApiService.StartLearningAsync( request );
            return Ok();
        }

        [HttpPost, Route( "room-stay/get-prediction" )]
        public IActionResult GetPrediction( [FromBody] GetCancellationPredictionDto request )
        {
            var response = _cancellationPredictionApiService.GetCancellationPredictions( request );
            return Ok( response );
        }
    }
}
