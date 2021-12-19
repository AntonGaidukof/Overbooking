using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.BookingCancellation
{
    [DataContract]
    public class BookingCancellationsDto
    {
        [DataMember( Name = "bookingCancellations" )]
        public BookingCancellationDto[] BookingCancellations { get; set; }
    }
}
