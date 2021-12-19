using System;

namespace TLOverbookingApplication.BookingCancellationExtraction.Entities
{
    public class BookingCancellationDto
    {
        public long ProviderId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public long RoomTypeId { get; set; }

        public int Amount { get; set; }
    }
}
