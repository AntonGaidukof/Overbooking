using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApplication.RoomStayFactExtraction.Convertors;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingApplication.WebClient;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingApplication.RoomStayFactExtraction.Services
{
    public class RoomStayFactExtractionService : IRoomStayFactExtractionService
    {
        private readonly IWebPmsWebClient _webPmsWebClient;
        private readonly IRoomStayFactConvertor _roomStayFactConvertor;
        private readonly IRoomStayFactService _roomStayFactService;

        public RoomStayFactExtractionService(
            IWebPmsWebClient webPmsWebClient,
            IRoomStayFactService roomStayFactService,
            IRoomStayFactConvertor roomStayFactConvertor )
        {
            _webPmsWebClient = webPmsWebClient;
            _roomStayFactService = roomStayFactService;
            _roomStayFactConvertor = roomStayFactConvertor;
        }

        public async Task ExtractRoomStayFactsAsync( long providerId )
        {
            /*
             * 1. Запрашиваем данные
             * 2. Конвертируем данные в Domain Model
             * 3. Сохраняем данные
             */
            DateTime startDate = DateTime.UtcNow.AddYears( -1 ).Date;
            DateTime endDate = DateTime.UtcNow.Date;
            GetRoomStayFactRQ request = new GetRoomStayFactRQ
            {
                Start = startDate,
                End = endDate,
                ProviderId = providerId
            };
            GetRoomStayFactRS response = await _webPmsWebClient.GetRoomStayFactsAsync( request );

            if ( response == null )
            {
                // TODO сделать типизированные исключения
                throw new Exception( "Invalid roomstay fact extraction response" );
            }

            RoomStayFact[] extractedRoomStayFacts = _roomStayFactConvertor.ConvertToRoomStayFact( response );
            List<RoomStayFact> currentRoomStayFacts = await _roomStayFactService.GetAsync( providerId, startDate, endDate );

            if ( currentRoomStayFacts.Count == 0 )
            {
                _roomStayFactService.AddRange( extractedRoomStayFacts );
                return;
            }

            List<RoomStayFact> newRoomStayFacts = new List<RoomStayFact>();
            foreach ( RoomStayFact roomStayFact in extractedRoomStayFacts )
            {
                // TODO переделать currentRoomStayFacts на словарь
                RoomStayFact currentRoomStayFact = currentRoomStayFacts.FirstOrDefault( rsf => rsf.ExternalId == roomStayFact.ExternalId );

                if ( currentRoomStayFact == null )
                {
                    newRoomStayFacts.Add( currentRoomStayFact );
                    continue;
                }

                currentRoomStayFact.AdultsAmount = roomStayFact.AdultsAmount;
                currentRoomStayFact.ChildrenAmount = roomStayFact.ChildrenAmount;
                currentRoomStayFact.CheckInDate = roomStayFact.CheckInDate;
                currentRoomStayFact.CheckOutDate = roomStayFact.CheckOutDate;
                currentRoomStayFact.DaysBetweenCheckInAndCanceling = roomStayFact.DaysBetweenCheckInAndCanceling;
                currentRoomStayFact.DuratuionInDays = roomStayFact.DuratuionInDays;
                currentRoomStayFact.IsCancelled = roomStayFact.IsCancelled;
                currentRoomStayFact.ProviderId = roomStayFact.ProviderId;
                currentRoomStayFact.RatePlanId = roomStayFact.RatePlanId;
                currentRoomStayFact.RoomId = roomStayFact.RoomId;
                currentRoomStayFact.RoomTypeId = roomStayFact.RoomTypeId;
                currentRoomStayFact.Total = roomStayFact.Total;
                newRoomStayFacts.Add( currentRoomStayFact );
            }

            _roomStayFactService.AddRange( newRoomStayFacts );
        }
    }
}
