using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayFact
{
    public interface IRoomStayFactService
    {
        void AddRange( IEnumerable<RoomStayFact> roomStayFacts );

        Task<List<RoomStayFact>> GetAsync( long providerId, DateTime start, DateTime end );

        Task<List<RoomStayFact>> GetAllAsync();
    }
}
