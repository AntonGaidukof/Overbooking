using System.Threading.Tasks;
using TLOverbookingApi.Dto;

namespace TLOverbookingApi.Services
{
    public interface IRoomStayFactApiService
    {
        Task ExtractAsync( long? providerId );

        void Add( RoomStayFactDto roomStayFactDto );

        Task<RoomStayFactDto[]> GetAllAsync();
    }
}
