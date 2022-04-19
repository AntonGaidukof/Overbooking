using TLOverbookingDomain.Abstractions;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public interface IRoomStayCancellationModelRepository : IBaseRepository<RoomStayCancellationModel>
    {
        RoomStayCancellationModel GetByProviderId( long providerId );
    }
}
