using System.Linq;
using TLOverbookingDomain.RoomStayCancellation;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Repositopries
{
    public class RoomStayCancellationModelRepository : BaseRepository<RoomStayCancellationModel>, IRoomStayCancellationModelRepository
    {
        public RoomStayCancellationModelRepository( TLOverbookingDbContext dbContext )
            : base( dbContext )
        {
        }

        public RoomStayCancellationModel GetByProviderId( long providerId )
        {
            return Entities.FirstOrDefault( e => e.ProviderId == providerId );
        }
    }
}
