using System;

namespace TLOverbookingApplication.BookingCancellationExtraction.Entities
{
    // TODO добавить поддержку временного периода
    public class GetBookingCancellationRQ
    {
        public long ProviderId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
