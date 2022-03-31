using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingDomain.RoomStayFact;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Repositopries
{
    public class RoomStayFactRepository : BaseRepository<RoomStayFact>, IRoomStayFactRepository
    {
        public RoomStayFactRepository( TLOverbookingDbContext dbContext )
            : base( dbContext )
        {
        }

        public IQueryable<RoomStayFact> Query => Entities;

        public Task<List<RoomStayFact>> GetAllAsync()
        {
            return Entities.ToListAsync();
        }

        public Task<List<RoomStayFact>> GetAllForProviderAsync( long providerId )
        {
            return Entities.Where( rsf => rsf.ProviderId == providerId ).ToListAsync();
        }

        public Task<RoomStayFact> GetByIdAsync( long roomStayFactId )
        {
            return Entities.FirstOrDefaultAsync( rsf => rsf.Id == roomStayFactId );
        }
    }
}
