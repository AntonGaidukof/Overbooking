using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.CancellationPrediction.RoomStay
{
    [DataContract]
    public class CancellationPredictionsDto
    {
        [DataMember( Name = "cancellationPredictions" )]
        public IReadOnlyList<CancellationPredictionDto> CancellationPredictions { get; set; }
    } 
}
