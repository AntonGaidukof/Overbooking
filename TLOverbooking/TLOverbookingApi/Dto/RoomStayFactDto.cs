using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto
{
    [DataContract]
    public class RoomStayFactDto
    {
        [DataMember( Name = "id" )]
        public string Id { get; set; }

        [DataMember( Name = "externalId" )]
        public string ExternalId { get; set; }

        [DataMember( Name = "cancellationDate" )]
        public string CancellationDate { get; set; }

        [DataMember( Name = "checkInDate" )]
        public string CheckInDate { get; set; }

        [DataMember( Name = "checkOutDate" )]
        public string CheckOutDate { get; set; }

        [DataMember( Name = "total" )]
        public string Total { get; set; }

        [DataMember( Name = "adultsAmount" )]
        public int AdultsAmount { get; set; }

        [DataMember( Name = "childrenAmount" )]
        public int ChildrenAmount { get; set; }

        [DataMember( Name = "roomTypeId" )]
        public string RoomTypeId { get; set; }

        [DataMember( Name = "roomId" )]
        public string RoomId { get; set; }

        [DataMember( Name = "ratePlanId" )]
        public string RatePlanId { get; set; }

        [DataMember( Name = "daysBetweenCheckInAndCanceling" )]
        public int? DaysBetweenCheckInAndCanceling { get; set; }

        [DataMember( Name = "duratuionInDays" )]
        public int DuratuionInDays { get; set; }

        [DataMember( Name = "isCancelled" )]
        public bool IsCancelled { get; set; }

        [DataMember( Name = "providerId" )]
        public string ProviderId { get; set; }
    }
}
