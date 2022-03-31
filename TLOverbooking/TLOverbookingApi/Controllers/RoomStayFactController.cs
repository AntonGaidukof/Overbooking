using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayFact;
using TLOverbookingApi.Services;

namespace TLOverbookingApi.Controllers
{
    [Route( "api/rooms-stay-fact" )]
    public class RoomStayFactController : Controller
    {
        private readonly IRoomStayFactApiService _roomStayFactApiService;

        public RoomStayFactController( IRoomStayFactApiService roomStayFactApiService )
        {
            _roomStayFactApiService = roomStayFactApiService;
        }

        [HttpGet, Route( "/extract/{providerId}" )]
        public async Task<IActionResult> ExtractAsync( long providerId )
        {
            await _roomStayFactApiService.ExtractAsync( providerId );
            return Ok();
        }

        [HttpPost, Route( "" )]
        public IActionResult Add( [FromBody] RoomStayFactsDto roomStayFactsDto )
        {
            _roomStayFactApiService.Add( roomStayFactsDto );
            return Ok();
        }

        [HttpGet, Route( "{providerId}" )]
        public async Task<IActionResult> GetAsync( long providerId )
        {
            return Ok( await _roomStayFactApiService.GetAllForProviderAsync( providerId ) );
        }
    }
}
