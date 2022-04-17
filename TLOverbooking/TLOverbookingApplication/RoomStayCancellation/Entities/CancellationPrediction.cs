namespace TLOverbookingApplication.RoomStayCancellation.Entities
{
    public class CancellationPrediction
    {
        public long RoomStayId { get; set; }

        public bool IsCancelled { get; set; }
    }
}
