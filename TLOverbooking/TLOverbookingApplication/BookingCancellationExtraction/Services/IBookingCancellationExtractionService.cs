using System;
using System.Threading.Tasks;

namespace TLOverbookingApplication.BookingCancellationExtraction.Services
{
    public interface IBookingCancellationExtractionService
    {
        Task ExtractBookingCancellationsAsync( long providerId, DateTime startDate, DateTime endDate );
    }
}
