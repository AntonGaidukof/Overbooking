using System.Collections.Generic;
using System.Runtime.Serialization;
using TLOverbookingApi.Dto.RoomStayFact;

namespace TLOverbookingApi.Dto.CancellationPrediction.RoomStay
{
    [DataContract]
    public class GetCancellationPredictionDto
    {
        [DataMember( Name = "providerId" )]
        public long ProviderId { get; set; }

        [DataMember( Name = "roomStayFacts" )]
        public IReadOnlyList<RoomStayForPredictionDto> RoomStays { get; set; }
    }
}
