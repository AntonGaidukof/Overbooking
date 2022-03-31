using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TLOverbookingApi.Dto.RoomStayFact
{
    [DataContract]
    public class RoomStayFactsDto
    {
        [DataMember( Name = "roomStayFacts" )]
        public List<RoomStayFactDto> RoomStayFacts { get; set; }
    }
}
