using System.Threading.Tasks;

namespace TLOverbookingApplication.RoomStayFactExtraction.Services
{
    public interface IRoomStayFactExtractionService
    {
        public Task ExtractRoomStayFactsAsync( long providerId );
    }
}
