using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.BookingCancellation
{
    [DataContract]
    public class GetBookingCancellationDto
    {
        [DataMember( Name = "providerId" )]
        public long ProviderId { get; set; }

        [DataMember( Name = "startDate" )]
        public string StartDate { get; set; }

        [DataMember( Name = "endDate" )]
        public string EndDate { get; set; }
    }
}
