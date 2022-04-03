using System.Runtime.Serialization;

namespace TLOverbookingApplication.RoomStayFactExtraction.Entities
{
    [DataContract]
    public class GetRoomStayFactRS
    {
        [DataMember( Name = "roomStayFacts" )]
        public RoomStayFactDto[] RoomStayFacts;
    }
}