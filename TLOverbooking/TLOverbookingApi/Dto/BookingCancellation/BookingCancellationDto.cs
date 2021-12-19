using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.BookingCancellation
{
    [DataContract]
    public class BookingCancellationDto
    {
        [DataMember( Name = "id" )]
        public long Id { get; set; }

        [DataMember( Name = "startDate" )]
        public string StartDate { get; set; }

        [DataMember( Name = "endDate" )]
        public string EndDate { get; set; }

        [DataMember( Name = "providerId" )]
        public long ProviderId { get; set; }

        [DataMember( Name = "roomTypeId" )]
        public long RoomTypeId { get; set; }

        [DataMember( Name = "amount" )]
        public int Amount { get; set; }
    }
}
