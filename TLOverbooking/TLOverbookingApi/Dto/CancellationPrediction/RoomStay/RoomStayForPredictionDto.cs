using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.CancellationPrediction.RoomStay
{
    [DataContract]
    public class RoomStayForPredictionDto
    {
        [DataMember( Name = "externalId" )]
        public long ExternalId { get; set; }

        [DataMember( Name = "checkInDate" )]
        public string CheckInDate { get; set; }

        [DataMember( Name = "checkOutDate" )]
        public string CheckOutDate { get; set; }

        [DataMember( Name = "total" )]
        public decimal Total { get; set; }

        [DataMember( Name = "adultsAmount" )]
        public int AdultsAmount { get; set; }

        [DataMember( Name = "childrenAmount" )]
        public int ChildrenAmount { get; set; }

        [DataMember( Name = "roomTypeId" )]
        public long RoomTypeId { get; set; }

        [DataMember( Name = "roomId" )]
        public long? RoomId { get; set; }

        [DataMember( Name = "ratePlanId" )]
        public long RatePlanId { get; set; }

        [DataMember( Name = "creationSource" )]
        public string CreationSource { get; set; }

        [DataMember( Name = "purposeKind" )]
        public string PurposeKind { get; set; }
    }
}
