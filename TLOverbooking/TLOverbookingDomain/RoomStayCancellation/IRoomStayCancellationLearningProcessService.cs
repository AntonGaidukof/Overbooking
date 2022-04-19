using System.Threading.Tasks;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public interface IRoomStayCancellationLearningProcessService
    {
        RoomStayCancellationLearningProcess GetCurrentActiveProcess( long providerId );

        void Add( RoomStayCancellationLearningProcess roomStayCancellationLearningProcess );
    }
}
