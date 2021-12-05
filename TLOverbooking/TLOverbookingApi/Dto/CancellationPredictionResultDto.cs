namespace TLOverbookingApi.Dto
{
    public class CancellationPredictionResultDto
    {
        public long RoomStayId { get; set; }

        public bool CanBeCancelled { get; set; }
    }
}
