using System.Runtime.Serialization;

namespace TLOverbookingApplication.RoomStayFactExtraction.Entities
{
    [DataContract]
    public class RoomStayFactDto
    {
        [DataMember( Name = "externalId" )]
        public long ExternalId { get; set; }

        [DataMember( Name = "bookingNumber" )]
        public string BookingNumber { get; set; }

        [DataMember( Name = "roomStayId" )]
        public long RoomStayId { get; set; }

        [DataMember( Name = "roomId" )]
        public long? RoomId { get; set; }

        [DataMember( Name = "roomTypeId" )]
        public long RoomTypeId { get; set; }

        [DataMember( Name = "ratePlanNameId" )]
        public long? RatePlanNameId { get; set; }

        [DataMember( Name = "paymentSystemId" )]
        public string PaymentSystemId { get; set; }

        [DataMember( Name = "adultsAmount" )]
        public int AdultsAmount { get; set; }

        [DataMember( Name = "childrenAmount" )]
        public int ChildrenAmount { get; set; }

        [DataMember( Name = "creationDate" )]
        public string CreationDate { get; set; }

        [DataMember( Name = "bookingCreationSource" )]
        public string BookingCreationSource { get; set; }

        [DataMember( Name = "cancellationDate" )]
        public string CancellationDate { get; set; }

        [DataMember( Name = "totalAmount" )]
        public decimal TotalAmount { get; set; }

        [DataMember( Name = "checkInDate" )]
        public string CheckInDate { get; set; }

        [DataMember( Name = "checkOutDate" )]
        public string CheckOutDate { get; set; }

        [DataMember( Name = "isCancelled" )]
        public bool IsCancelled { get; set; }
    }
}
