using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.CancellationPrediction.RoomStay
{
    [DataContract]
    public class ModelStartLearningDto
    {
        [DataMember( Name = "providerId" )]
        public long ProviderId { get; set; }

        [DataMember( Name = "startExtraction" )]
        public bool StartExtraction { get; set; }
    }
}
