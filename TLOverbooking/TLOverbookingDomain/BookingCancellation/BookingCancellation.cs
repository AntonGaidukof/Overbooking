using System;

namespace TLOverbookingDomain.BookingCancellation
{
    public class BookingCancellation
    {
        public long Id { get; set; }

        public long ProviderId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int Amount { get; set; }

        public long RoomTypeId { get; set; }
    }
}
