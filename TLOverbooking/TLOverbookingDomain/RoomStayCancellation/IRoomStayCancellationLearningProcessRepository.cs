using System.Threading.Tasks;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public interface IRoomStayCancellationLearningProcessRepository : IBaseRepository<RoomStayCancellationLearningProcess>
    {
        Task<RoomStayCancellationLearningProcess> GetAsync( long providerId, LearningStatus learningStatus );

        Task<RoomStayCancellationLearningProcess> GetLastAsync( long providerId );
    }
}
