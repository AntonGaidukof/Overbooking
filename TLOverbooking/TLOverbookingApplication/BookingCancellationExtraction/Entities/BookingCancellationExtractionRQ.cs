using System;

namespace TLOverbookingApplication.BookingCancellationExtraction.Entities
{
    // TODO добавить поддержку временного периода
    public class BookingCancellationExtractionRQ
    {
        public long ProviderId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
