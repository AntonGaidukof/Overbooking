using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayFact
{
    public interface IRoomStayFactService
    {
        void AddRange( IEnumerable<RoomStayFact> roomStayFacts );

        Task<List<RoomStayFact>> GetAllForProviderAsync( long providerId );

        Task<List<RoomStayFact>> GetAllAsync();
    }
}
