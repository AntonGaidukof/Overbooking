using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.BookingCancellation;
using TLOverbookingApi.Services;

namespace TLOverbookingApi.Controllers
{
    [Route( "api/booking-cancellation" )]
    public class BookingCancellationController : Controller
    {
        private readonly IBookingCancellationApiService _bookingCancellationApiService;

        public BookingCancellationController( IBookingCancellationApiService bookingCancellationApiService )
        {
            _bookingCancellationApiService = bookingCancellationApiService;
        }

        [HttpGet, Route( "" )]
        public async Task<IActionResult> GetBookingCancellationsAsync( GetBookingCancellationDto getBookingCancellationRQ )
        {
            return Ok( await _bookingCancellationApiService.GetBookingCancellationsAsync( getBookingCancellationRQ ) );
        }

        [HttpPost, Route( "" )]
        public async Task<IActionResult> SaveBookingCancellationsAsync( [FromBody] BookingCancellationsDto bookingCancellationsDto )
        {
            await _bookingCancellationApiService.SaveBookingCancellationsAsync( bookingCancellationsDto );
            return Ok();
        }

        [HttpDelete, Route( "" )]
        public async Task<IActionResult> DeleteAllProviderBookingCancellationsAsync( long providerId )
        {
            await _bookingCancellationApiService.DeleteAllProviderBookingCancellationsAsync( providerId );
            return Ok();
        }

        [HttpPost, Route( "/extract" )]
        public async Task<IActionResult> ExtractBookingCancellationsAsync( ExtractBookingCancellationsDto extractBookingCancellationsDto )
        {
            return Ok( await _bookingCancellationApiService.ExtractBookingCancellationsAsync( extractBookingCancellationsDto ) );
        }
    }
}
