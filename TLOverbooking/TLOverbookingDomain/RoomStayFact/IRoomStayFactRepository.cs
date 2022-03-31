using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingDomain.RoomStayFact
{
    public interface IRoomStayFactRepository : IBaseRepository<RoomStayFact>
    {
        IQueryable<RoomStayFact> Query { get; }

        Task<RoomStayFact> GetByIdAsync( long roomStayFactId );

        Task<List<RoomStayFact>> GetAllAsync();

        Task<List<RoomStayFact>> GetAllForProviderAsync( long providerId );
    }
}
