using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;

namespace TLOverbookingApplication.BookingCancellationExtraction.Extractors
{
    public interface IBookingCancellationExtractor
    {
        public Task<BookingCancellationExtractionRS> GetBookingCancellationsAsync( BookingCancellationExtractionRQ bookingCancellationExtractionRQ );
    }
}
