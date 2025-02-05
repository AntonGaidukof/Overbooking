﻿using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingApplication.RoomStayFactExtraction.Convertors
{
    public interface  IRoomStayFactConvertor
    {
        RoomStayFact[] ConvertToRoomStayFact( GetRoomStayFactRS roomStayFactExtractionRS, long providerId );
    }
}
