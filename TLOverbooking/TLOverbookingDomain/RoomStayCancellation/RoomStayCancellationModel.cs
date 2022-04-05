using System;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public class RoomStayCancellationModel
    {
        public long Id { get; set; }

        public long ProviderId { get; set; }

        public string Path { get; set; }

        public DateTime LastLearningDate { get; set; }
    }
}
