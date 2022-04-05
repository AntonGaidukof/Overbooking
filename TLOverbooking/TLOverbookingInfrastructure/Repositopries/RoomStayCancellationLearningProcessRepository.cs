using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingDomain.RoomStayCancellation;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Repositopries
{
    public class RoomStayCancellationLearningProcessRepository : BaseRepository<RoomStayCancellationLearningProcess>, IRoomStayCancellationLearningProcessRepository
    {
        public RoomStayCancellationLearningProcessRepository( TLOverbookingDbContext dbContext )
            : base( dbContext )
        {
        }

        public Task<RoomStayCancellationLearningProcess> GetAsync( long providerId, LearningStatus learningStatus )
        {
            return GetQuery().FirstOrDefaultAsync( e => e.ProviderId == providerId && e.Status == learningStatus );
        }

        public Task<RoomStayCancellationLearningProcess> GetLastAsync( long providerId )
        {
            return GetQuery().Where( e => e.ProviderId == providerId ).OrderByDescending( e => e.TimeStampUtc ).FirstAsync();
        }
    }
}
