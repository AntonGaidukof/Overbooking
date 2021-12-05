using System;

namespace TLOverbookingDomain.RoomStayFact
{
    public class RoomStayFact
    {
        public long Id { get; set; }
        public bool IsCancelled { get; set; }
        
        public int DuratuionInDays { get; set; }
        
        public DateTime CheckInDate { get; set; }
        
        public DateTime CheckOutDate { get; set; }

        public decimal Total { get; set; }

        public int AdultsAmount { get; set; }

        public int ChildrenAmount { get; set; }

        public long RoomTypeId { get; set; }

        public long RoomId { get; set; }

        public long RatePlanId { get; set; }

        public int? DaysBetweenCheckInAndCanceling { get; set; }
    }
}
