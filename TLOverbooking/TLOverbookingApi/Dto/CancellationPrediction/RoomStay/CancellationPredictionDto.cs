using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.CancellationPrediction.RoomStay
{
    [DataContract]
    public class CancellationPredictionDto
    {
        [DataMember( Name = "externalId" )]
        public long ExternalId { get; set; }

        [DataMember( Name = "isCancelled" )]
        public bool IsCancelled { get; set; }
    }
}
