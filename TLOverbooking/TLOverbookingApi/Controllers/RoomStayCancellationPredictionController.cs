using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayCancellationPrediction;
using TLOverbookingApi.Services;

namespace TLOverbookingApi.Controllers
{
    [Route( "api/room-stay-cancellation-prediction" )]
    public class RoomStayCancellationPredictionController : Controller
    {
        private readonly IRoomStayCancellationPredictionApiService _roomStayCancellationPredictionApiService;

        public RoomStayCancellationPredictionController( IRoomStayCancellationPredictionApiService roomStayCancellationPredictionApiService )
        {
            _roomStayCancellationPredictionApiService = roomStayCancellationPredictionApiService;
        }

        [HttpPost, Route( "/start-learning" )]
        public async Task<IActionResult> StartLearningAsync( [FromBody] ModelStartLearningDto request )
        {
            await _roomStayCancellationPredictionApiService.StartLearningAsync( request );
            return Ok();
        }
    }
}
