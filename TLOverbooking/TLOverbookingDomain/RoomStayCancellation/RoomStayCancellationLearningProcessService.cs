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

        public Task<RoomStayCancellationLearningProcess> GetAsync( long providerId, LearningStatus learningStatus )
        {
            return _repository.GetAsync( providerId, learningStatus );
        }
    }
}
