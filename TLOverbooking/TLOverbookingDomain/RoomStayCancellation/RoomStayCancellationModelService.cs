namespace TLOverbookingDomain.RoomStayCancellation
{
    public class RoomStayCancellationModelService : IRoomStayCancellationModelService
    {
        private readonly IRoomStayCancellationModelRepository _repository;

        public RoomStayCancellationModelService( IRoomStayCancellationModelRepository repository )
        {
            _repository = repository;
        }

        public RoomStayCancellationModel Get( long providerId )
        {
            return _repository.GetByProviderId( providerId );
        }
    }
}
