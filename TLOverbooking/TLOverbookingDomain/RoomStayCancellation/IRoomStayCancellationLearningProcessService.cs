using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public interface IRoomStayCancellationLearningProcessService
    {
        Task<RoomStayCancellationLearningProcess> GetAsync( long providerId, LearningStatus learningStatus );

        void Add( RoomStayCancellationLearningProcess roomStayCancellationLearningProcess );
    }
}
