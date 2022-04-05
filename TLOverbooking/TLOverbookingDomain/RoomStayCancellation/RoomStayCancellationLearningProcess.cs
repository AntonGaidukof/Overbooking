using System;

namespace TLOverbookingDomain.RoomStayCancellation
{
    public class RoomStayCancellationLearningProcess
    {
        public long Id { get; set; }

        public long ProviderId { get; set; }

        public LearningStatus Status { get; set; }

        public DateTime TimeStampUtc { get; set; } 
    }
}
