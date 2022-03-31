using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayFact;

namespace TLOverbookingApi.Services
{
    public interface IRoomStayFactApiService
    {
        Task ExtractAsync( long providerId );

        void Add( RoomStayFactsDto roomStayFactsDto );

        Task<RoomStayFactsDto> GetAllForProviderAsync( long providerId );
    }
}
