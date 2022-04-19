using System.Linq;
using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public class RoomStayCancellationLearningProcessService : IRoomStayCancellationLearningProcessService
    {
        private readonly IRoomStayCancellationLearningProcessRepository _repository;

        public RoomStayCancellationLearningProcessService( IRoomStayCancellationLearningProcessRepository repository )
        {
            _repository = repository;
        }

        public void Add( RoomStayCancellationLearningProcess roomStayCancellationLearningProcess )
        {
            _repository.Add( roomStayCancellationLearningProcess );
        }

        public RoomStayCancellationLearningProcess GetCurrentActiveProcess( long providerId )
        {
            return _repository.GetQuery().FirstOrDefault( e => e.ProviderId == providerId && e.Status != LearningStatus.Finished );
        }
    }
}
