using System.Threading.Tasks;
using TLOverbookingApi.Dto.BookingCancellation;

namespace TLOverbookingApi.Services
{
    public interface IBookingCancellationApiService
    {
        public Task<BookingCancellationsDto> GetBookingCancellationsAsync( GetBookingCancellationDto request );

        public Task SaveBookingCancellationsAsync( BookingCancellationsDto bookingCancellationDtos );

        public Task DeleteAllProviderBookingCancellationsAsync( long providerId );

        public Task<bool> ExtractBookingCancellationsAsync( ExtractBookingCancellationsDto extractBookingCancellationsDto );
    }
}
