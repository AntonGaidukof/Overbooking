using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingDomain.BookingCancellation;

namespace TLOverbookingApplication.BookingCancellationExtraction.Services
{
    public interface IBookingCancellationExtractionService
    {
        Task<List<BookingCancellation>> ExtractBookingCancellationsAsync( long providerId, DateTime startDate, DateTime endDate );
    }
}
