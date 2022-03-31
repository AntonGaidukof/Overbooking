using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayFact
{
    public class RoomStayFactService : IRoomStayFactService
    {
        private readonly IRoomStayFactRepository _roomStayFactRepository;

        public RoomStayFactService( IRoomStayFactRepository roomStayFactRepository )
        {
            _roomStayFactRepository = roomStayFactRepository;
        }

        public void AddRange( IEnumerable<RoomStayFact> roomStayFacts )
        {
            _roomStayFactRepository.AddRange( roomStayFacts );
        }

        public Task<List<RoomStayFact>> GetAllAsync()
        {
            return _roomStayFactRepository.GetAllAsync();
        }

        public Task<List<RoomStayFact>> GetAllForProviderAsync( long providerId )
        {
            return _roomStayFactRepository.GetAllForProviderAsync( providerId );
        }
    }
}
