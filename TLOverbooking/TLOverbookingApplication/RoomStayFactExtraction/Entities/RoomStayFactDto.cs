using System;

namespace TLOverbookingApplication.RoomStayFactExtraction.Entities
{
    public class RoomStayFactDto
    {
        public long ExternalId { get; set; }
        
        public DateTime? CancellationDate { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal Total { get; set; }

        public int AdultsAmount { get; set; }

        public int ChildrenAmount { get; set; }

        public long RoomTypeId { get; set; }

        public long RoomId { get; set; }

        public long RatePlanId { get; set; }
    }
}
