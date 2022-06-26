namespace TLOverbookingDomain.RoomStayCancellation
{
    public interface IRoomStayCancellationModelService
    {
        RoomStayCancellationModel Get( long providerId );

        RoomStayCancellationModel Rebuild( long providerId );
    }
}
