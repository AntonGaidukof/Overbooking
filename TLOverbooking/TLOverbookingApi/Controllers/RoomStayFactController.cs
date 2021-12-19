using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto;
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
        public async Task<IActionResult> ExtractAsync( long? providerId )
        {
            await _roomStayFactApiService.ExtractAsync( providerId );
            return Ok();
        }

        [HttpPost, Route( "" )]
        public IActionResult Add( RoomStayFactDto roomStayFactDto )
        {
            _roomStayFactApiService.Add( roomStayFactDto );
            return Ok();
        }

        [HttpGet, Route( "" )]
        public async Task<IActionResult> GetAsync()
        {
            return Ok( await _roomStayFactApiService.GetAllAsync() );
        }
    }
}
