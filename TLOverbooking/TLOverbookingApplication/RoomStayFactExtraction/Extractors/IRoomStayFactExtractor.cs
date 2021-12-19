using System.Threading.Tasks;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;

namespace TLOverbookingApplication.RoomStayFactExtraction.Extractors
{
    public interface IRoomStayFactExtractor
    {
        public Task<RoomStayFactExtractionRS> GetRoomStayFactAsync( RoomStayFactExtractionRQ roomStayFactExtractionRQ );
    }
}
