using System;
using System.Linq;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingApplication.RoomStayFactExtraction.Convertors
{
    public class RoomStayFactConvertor : IRoomStayFactConvertor
    {
        RoomStayFact[] IRoomStayFactConvertor.ConvertToRoomStayFact( GetRoomStayFactRS roomStayFactExtractionRS, long providerId )
        {
            return roomStayFactExtractionRS.RoomStayFacts.Select( rs => new RoomStayFact
            {
                AdultsAmount = rs.AdultsAmount,
                CheckInDate = DateTime.Parse( rs.CheckInDate ),
                CheckOutDate = DateTime.Parse( rs.CheckOutDate ),
                ChildrenAmount = rs.ChildrenAmount,
                DaysBetweenCheckInAndCanceling = 0,
                DuratuionInDays = 0,
                ExternalId = rs.ExternalId,
                IsCancelled = rs.IsCancelled,
                ProviderId = providerId,
                RatePlanId = rs.RatePlanNameId ?? default,
                RoomId = rs.RoomId ?? default,
                RoomTypeId = rs.RoomTypeId,
                Total = rs.TotalAmount
            } ).ToArray();
        }
    }
}
