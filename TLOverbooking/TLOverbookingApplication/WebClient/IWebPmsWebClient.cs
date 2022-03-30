using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;

namespace TLOverbookingApplication.WebClient
{
    public interface IWebPmsWebClient
    {
        Task<GetBookingCancellationRS> GetBookingCancellationsAsync( GetBookingCancellationRQ request );

        Task<GetRoomStayFactRS> GetRoomStayFactsAsync( GetRoomStayFactRQ request );
    }
}
