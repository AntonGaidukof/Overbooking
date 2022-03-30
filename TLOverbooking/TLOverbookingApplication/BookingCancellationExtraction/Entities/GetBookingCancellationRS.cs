using System.Collections.Generic;

namespace TLOverbookingApplication.BookingCancellationExtraction.Entities
{
    public class GetBookingCancellationRS
    {
        public List<BookingCancellationDto> BookingCancellations { get; set; }
    }
}
